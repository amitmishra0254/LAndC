using ATMMachine.Entities;

namespace ATMMachine.DAL.Repositories.Interfaces
{
    public interface AccountRepository
    {
        Task<Account> GetAccountByCardNumber(string cardNumber);
        Task<bool> IsValidCardNumber(string cardNumber);
        Task<int> UpdateAccount(Account account);
    }
}
