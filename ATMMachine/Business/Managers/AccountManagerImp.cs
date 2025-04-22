using ATMMachine.Business.Interfaces;
using ATMMachine.Constants;
using ATMMachine.DAL.Repositories.Interfaces;
using ATMMachine.DTOs;
using ATMMachine.Entities;
using ATMMachine.Exceptions;
using ATMMachine.Utilities;

namespace ATMMachine.Business.Managers
{
    public class AccountManagerImp : AccountManager
    {
        private readonly AccountRepository _accountRepository;
        private readonly UserRepository _userRepository;
        private readonly UserManager _userManager;
        private readonly ATMServices _atmServices;
        public AccountManagerImp(AccountRepository _accountRepository, 
            UserRepository userRepository, 
            UserManager _userManager, 
            ATMServices _atmServices)
        {
            this._accountRepository = _accountRepository;
            this._userRepository = userRepository;
            this._userManager = _userManager;
            this._atmServices = _atmServices;
        }

        public async Task<decimal> WithdrawalMoney(WithdrawalDTO withdrawalDTO)
        {
            Account account = await GetAccount(withdrawalDTO.CardNumber);
            if (await IsCardBlocked(account))
            {
                throw new CardBlockedException(ApplicationConstant.CardBlockException);
            }
            if (!await this._userManager.IdValidCardPin(account, withdrawalDTO))
            {
                if (account.IsCardBlocked)
                {
                    throw new CardBlockedException(ApplicationConstant.CardBlockExceptionWithLastAttempt,withdrawalDTO.CardNumber);
                }
                throw new CardBlockedException(ApplicationConstant.CardBlockExceptionWithAttempts, withdrawalDTO.CardNumber, ApplicationConstant.InvalidPinLimit - account.FailedPinAttempts);
            }
            if (account.Balance < withdrawalDTO.Amount)
            {
                throw new InsufficientBalanceException(ApplicationConstant.InsufficientBalanceMessage);
            }
            if (!await this._atmServices.HasSufficientCash(withdrawalDTO.AtmId,withdrawalDTO.Amount))
            {
                throw new InsufficientBalanceException(ApplicationConstant.InsufficientAtmCashMessage);
            }
            if(account.DailyLimit < withdrawalDTO.Amount + account.TodayWithdrawnAmount)
            {
                throw new DailyLimitExceededException(ApplicationConstant.DailyLimitExceededMessage);
            }

            await this._atmServices.WithdrawalMoney(withdrawalDTO);

            account.Balance -= withdrawalDTO.Amount;
            account.TodayWithdrawnAmount += withdrawalDTO.Amount;

            await this._accountRepository.UpdateAccount(account);
            return account.Balance;
        }

        public async Task<decimal> DepositMoney(DepositRequestDTO depositDTO)
        {
            Account account = await GetAccount(depositDTO.CardNumber);
            if(await IsCardBlocked(account))
            {
                throw new CardBlockedException(ApplicationConstant.CardBlockException);
            }
            account.Balance += depositDTO.Amount;
            await this._atmServices.DepositMoney(depositDTO.ATMId,depositDTO.Amount);
            await this._accountRepository.UpdateAccount(account);
            return account.Balance;
        }

        public async Task<Account> GetAccount(string cardNumber)
        {
            Account account = await this._accountRepository.GetAccountByCardNumber(cardNumber);
            if (account == null)
            {
                throw new NotFoundException(ApplicationConstant.UserNotFoundException, cardNumber);
            }
            return account;
        }

        private async Task<bool> IsCardBlocked(Account account)
        {
            return account.IsCardBlocked;
        }
    }
}
