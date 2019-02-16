using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankSimulator.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BankSimulator.API.Data
{
    public class PaymantsRepository : IPaymantsRepository
    {
        private readonly DataContext _context;

        public PaymantsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Credit(string UserLogin, decimal CreditAmount)
        {
            foreach (var user in _context.Accounts)
            {
                if (user.Login == UserLogin)
                    user.Cash = user.Cash + CreditAmount; 
            }

            await _context.SaveChangesAsync();
        }

        public Task<decimal> ReturnCurrentCash(string userLogin)
        {
            foreach (var user in _context.Accounts)
            {
                if(user.Login == userLogin)
                {
                    return Task.FromResult(user.Cash);
                }
            }

            return null;
        }

        public async Task<string> Transfer(string recivingUser, string sendingUser, decimal cash)
        {
            foreach (var user in _context.Accounts)
            {
                if (user.Cash < cash && sendingUser == user.Login)
                    return "You don't have enough money";

                if (user.Login == sendingUser)
                    user.Cash -= cash;

                if (user.Login == recivingUser)
                    user.Cash += cash;
            }

            await _context.SaveChangesAsync();
            return "Succesfully";
        }

        public async Task<bool> UserExists(string recivingUser)
        {
            if (await _context.Accounts.AnyAsync(x => x.Login == recivingUser))
                return true;

            return false;
        }
    }
}
