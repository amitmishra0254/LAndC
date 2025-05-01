using ATMMachine.Entities;
using System.Linq.Expressions;

namespace ATMMachine.DAL.Repositories.Interfaces
{
    public interface UserRepository
    {
        Task<int> CreateUser(User user);
        Task<int> UpdateUser(User user);
    }
}
