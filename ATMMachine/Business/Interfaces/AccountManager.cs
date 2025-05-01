using ATMMachine.DTOs;
using ATMMachine.Entities;

namespace ATMMachine.Business.Interfaces
{
    public interface AccountManager
    {
        Task<decimal> WithdrawalMoney(WithdrawalDTO withdrawalDTO);
        Task<decimal> DepositMoney(DepositRequestDTO depositDTO);
        Task<Account> GetAccount(string cardNumber);
    }
}
