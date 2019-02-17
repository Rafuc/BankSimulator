﻿using BankSimulator.API.Dtos;
using BankSimulator.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankSimulator.API.Data
{
    public interface IPaymantsRepository
    {
        Task<string> Transfer(string recivingUser, string sendingUser, decimal cash, string title);

        Task<bool> UserExists(string recivingUser);

        Task<string> Credit(int id,decimal CreditAmount,string date,int rateOfIntrest,string creditPaymantTime,decimal remainingCredit);

        Task<decimal> ReturnCurrentCash(string userLogin);

        Task<string> RepaymantCredit(RepaymantCredit repaymantCredit);
    }
}
