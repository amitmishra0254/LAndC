using ATMMachine.DAL.Context;
using ATMMachine.DAL.Repositories.Interfaces;
using ATMMachine.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ATMMachine.DAL.Repositories
{
    public class UserRepositoryImp : UserRepository
    {
        private readonly ATMDbContext _context;
        public UserRepositoryImp(ATMDbContext _context) 
        {
            this._context = _context;
        }

        public async Task<int> CreateUser(User user)
        {
            await this._context.Users.AddAsync(user);
            await this._context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<int> UpdateUser(User user)
        {
            this._context.Users.Update(user);
            return await this._context.SaveChangesAsync();
        }
    }
}
