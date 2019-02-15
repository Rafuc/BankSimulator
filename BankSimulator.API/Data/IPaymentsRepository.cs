using BankSimulator.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankSimulator.API.Data
{
    public interface IPaymentsRepository
    {
        Task<Account> Transfer(decimal transfer, string userSend, string userGet, string titleOfTransfer);
        Task<bool> UserExists(string username);
    }
}
