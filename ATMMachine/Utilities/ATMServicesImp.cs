using ATMMachine.DAL.Context;
using ATMMachine.DAL.Repositories.Interfaces;
using ATMMachine.DTOs;
using ATMMachine.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ATMMachine.Utilities
{
    public class ATMServicesImp : ATMServices
    {
        private readonly ATMDbContext _context;
        public ATMServicesImp(ATMDbContext _context)
        {
            this._context = _context;
        }

        public async Task<bool> IsValidATM(int atmId)
        {
            return await this._context.ATMs.AnyAsync(atm => atm.Id == atmId);
        }

        public async Task<bool> HasSufficientCash(int atmId, decimal amount)
        {
            if(await IsValidATM(atmId))
            {
                return await this._context.ATMs.AnyAsync(atm => atm.Id == atmId && atm.AvailableCash >= amount);
            }
            throw new Exception($"ATM with Id {atmId} Not Found.");
        }

        public async Task WithdrawalMoney(WithdrawalDTO withdrawalDTO)
        {
            ATM atm = await GetATM(atm => atm.Id == withdrawalDTO.AtmId);
            atm.AvailableCash -= withdrawalDTO.Amount;
            this._context.ATMs.Update(atm);
            await this._context.SaveChangesAsync();
        }

        public async Task DepositMoney(int atmId, decimal amount)
        {
            ATM atm = await GetATM(atm => atm.Id == atmId);
            atm.AvailableCash += amount;
            this._context.ATMs.Update(atm);
            await this._context.SaveChangesAsync();
        }

        private async Task<ATM> GetATM(Expression<Func<ATM,bool>> expression)
        {
            return await this._context.ATMs.FirstOrDefaultAsync(expression);
        }
    }
}
