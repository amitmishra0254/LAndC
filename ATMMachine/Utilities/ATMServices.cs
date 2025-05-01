using ATMMachine.DTOs;

namespace ATMMachine.Utilities
{
    public interface ATMServices
    {
        Task<bool> HasSufficientCash(int atmId, decimal amount);
        Task WithdrawalMoney(WithdrawalDTO withdrawalDTO);
        Task DepositMoney(int atmId, decimal amount);
    }
}
