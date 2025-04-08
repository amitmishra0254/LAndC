using System.Linq.Expressions;
using UserManagement.Entities;

namespace UserManagement.DAL.Repositories
{
    public interface UserRepository
    {
        Task<int> UpdateUser(User user);
        Task<User> GetUser(int Id);
        Task<int> DeleteUser(int Id);
        Task<int> CreateUser(User user);
        Task<bool> IsAnyUserPresent(Expression<Func<User, bool>> expression);
    }
}
