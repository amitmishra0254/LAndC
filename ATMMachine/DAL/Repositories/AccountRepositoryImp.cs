using ATMMachine.DAL.Context;
using ATMMachine.DAL.Repositories.Interfaces;
using ATMMachine.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace ATMMachine.DAL.Repositories
{
    public class AccountRepositoryImp : AccountRepository
    {
        private readonly ATMDbContext _context;
        public AccountRepositoryImp(ATMDbContext _context)
        {
            this._context = _context;
        }

        public async Task<Account> GetAccountByCardNumber(string cardNumber)
        {
            return await this._context.Accounts
                .Where(account => account.CardNumber == cardNumber)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> IsValidCardNumber(string cardNumber)
        {
            return await this._context.Accounts.AnyAsync(account => account.CardNumber == cardNumber);
        }

        public async Task<int> UpdateAccount(Account account)
        {
            this._context.Accounts.Update(account);
            return await this._context.SaveChangesAsync();
        }
    }
}
