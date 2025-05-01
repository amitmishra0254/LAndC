using ATMMachine.DTOs;
using ATMMachine.Entities;

namespace ATMMachine.Business.Interfaces
{
    public interface UserManager
    {
        Task<int> CreateUser(CreateUserRequestDTO createUserRequestDTO);
        Task<bool> IdValidCardPin(Account account, WithdrawalDTO withdrawalDTO);
    }
}
