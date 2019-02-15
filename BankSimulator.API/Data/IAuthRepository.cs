using BankSimulator.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankSimulator.API.Data
{
    public interface IAuthRepository
    {
        Task<Account> Register(Account account, string password);

        Task<Account> Login(string username, string password);

        Task<bool> UserExists(string username);
    }
}
