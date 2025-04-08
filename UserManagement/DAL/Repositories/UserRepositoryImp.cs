using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Linq.Expressions;
using UserManagement.Entities;
using UserManagement.Exceptions;
using UserManagement.Utilities;

namespace UserManagement.DAL.Repositories
{
    public class UserRepositoryImp : UserRepository
    {
        private readonly UserContext userContext;
        public UserRepositoryImp(UserContext userContext)
        {
            this.userContext = userContext;
        }

        public async Task<int> CreateUser(User user)
        {
            await this.userContext.Users.AddAsync(user);
            await this.userContext.SaveChangesAsync();
            return user.Id;
        }

        public async Task<int> DeleteUser(int Id)
        {
            User user = await this.userContext.Users.Where(user => user.Id == Id).FirstOrDefaultAsync();
            if(user != null)
            {
                this.userContext.Users.Remove(user);
                return await this.userContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<User> GetUser(int Id)
        {
            User user = await this.userContext.Users.Where(user => user.Id == Id).AsNoTracking().FirstOrDefaultAsync();
            if (user != null)
            {
                return user;
            }
            throw new NotFoundException(ApplicationConstants.UserNotFoundException + Id.ToString());
        }

        public async Task<int> UpdateUser(User user)
        { 
            this.userContext.Users.Update(user);
            return await this.userContext.SaveChangesAsync();
        }

        public async Task<bool> IsAnyUserPresent(Expression<Func<User,bool>> expression)
        {
            return await this.userContext.Users.AsNoTracking().AnyAsync(expression);
        }
    }

    public interface UserRepository
    {
        Task<int> UpdateUser(User user);
        Task<User> GetUser(int Id);
        Task<int> DeleteUser(int Id);
        Task<int> CreateUser(User user);
        Task<bool> IsAnyUserPresent(Expression<Func<User, bool>> expression);
    }
}
