using BankSimulator.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankSimulator.API.Data
{
    public interface IPaymantsRepository
    {
        Task<string> Transfer(string recivingUser, string sendingUser, decimal cash);

        Task<bool> UserExists(string recivingUser);

        Task Credit(int id,decimal CreditAmount,string date,int rateOfIntrest,string creditPaymantTime,decimal remainingCredit);

        Task<decimal> ReturnCurrentCash(string userLogin);
    }
}
