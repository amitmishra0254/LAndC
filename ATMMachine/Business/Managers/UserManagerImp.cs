using ATMMachine.Business.Interfaces;
using ATMMachine.Constants;
using ATMMachine.DAL.Repositories.Interfaces;
using ATMMachine.DTOs;
using ATMMachine.Entities;
using ATMMachine.Utilities;
using System.Net.NetworkInformation;

namespace ATMMachine.Business.Managers
{
    public class UserManagerImp : UserManager
    {
        private readonly AccountRepository _accountRepository;
        private readonly UserRepository _userRepository;

        public UserManagerImp(UserRepository _userRepository, 
            AccountRepository _accountRepository)
        {
            this._userRepository = _userRepository;
            this._accountRepository = _accountRepository;
        }

        public async Task<int> CreateUser(CreateUserRequestDTO createUserRequestDTO)
        {
            User user = new User()
            {
                FullName = createUserRequestDTO.FullName,
                Email = createUserRequestDTO.Email,
                MobileNumber = createUserRequestDTO.MobileNumber,
                Address = createUserRequestDTO.Address,
                Account = new Account()
                {
                    CardNumber = await GenerateUniqueCardNumber(),
                    Pin = createUserRequestDTO.AccountDetails.Pin,
                    Balance = 0,
                    DailyLimit = createUserRequestDTO.AccountDetails.AccountType == Enums.AccountType.Saving ? ApplicationConstant.SavingAccountDailyLimt : ApplicationConstant.CurrentAccountDailyLimt,
                    TodayWithdrawnAmount = 0,
                    IsCardBlocked = false,
                    FailedPinAttempts = 0,
                    AccountType = createUserRequestDTO.AccountDetails.AccountType,
                }
            };

            return await this._userRepository.CreateUser(user);
        }

        public async Task<bool> IdValidCardPin(Account account, WithdrawalDTO withdrawalDTO)
        {
            bool result = false;
            if(account.Pin == withdrawalDTO.Pin)
            {
                account.FailedPinAttempts = 0;
                result = true;
            }
            account.FailedPinAttempts++;
            if(account.FailedPinAttempts == ApplicationConstant.InvalidPinLimit)
            {
                account.IsCardBlocked = true;
            }
            await this._accountRepository.UpdateAccount(account);
            return result;
        }

        private async Task<string> GenerateUniqueCardNumber()
        {
            string cardNumber;
            var random = new Random();

            do
            {
                cardNumber = "";
                for (int i = 0; i < 4; i++)
                {
                    cardNumber += random.Next(1000, 9999).ToString();
                }
            }
            while (await _accountRepository.IsValidCardNumber(cardNumber));

            return cardNumber;
        }
    }
}
