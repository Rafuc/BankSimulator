using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankSimulator.API.Models;
using BankSimulator.API.Models.Entity;
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

        public async Task<string> Credit(int id, decimal CreditAmount, string date, int rateOfIntrest, string creditPaymantTime, decimal remainingCredit)
        {
            bool canTakingCredit = true;

            foreach(var history in _context.CreditHistories)
            {
                if(id == history.IDPersonTakinCredit)
                {
                    canTakingCredit = false;
                }
                else
                {
                    canTakingCredit = true;
                }
            }

            if (canTakingCredit)
            {
                var createCreditHistory = new CreditHistory
                {
                    IDPersonTakinCredit = id,
                    CreditAmmount = CreditAmount,
                    Date = date,
                    RateOfIntrest = rateOfIntrest,
                    CreditPaymentTime = creditPaymantTime,
                    RemainingCredit = remainingCredit
                };


                foreach (var user in _context.Accounts)
                {
                    if (user.IdUser == id)
                    {
                        user.Cash = user.Cash + CreditAmount;
                    }
                }

                await _context.AddAsync(createCreditHistory);
                await _context.SaveChangesAsync();

                return "Succesfully";
            }

            return "You can't take credit";
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

        public async Task<string> Transfer(string recivingUser, string sendingUser, decimal cash, string title)
        {
            decimal moneyBefore = 0M;
            int userID = 0;

            foreach (var user in _context.Accounts)
            {
                if (user.Cash < cash && sendingUser == user.Login)
                    return "You don't have enough money";

                if (user.Login == sendingUser)
                {
                    moneyBefore = user.Cash;
                    user.Cash -= cash;
                    userID = user.IdUser;
                }

                if (user.Login == recivingUser)
                    user.Cash += cash;
            }

            var transactionHistory = new TransactionHistory
            {
                MoneyBefore = moneyBefore,
                MoneyAfter = moneyBefore - cash,
                TitleOfTransaction = title,
                IdUser = userID
            };

            await _context.AddAsync(transactionHistory);
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
