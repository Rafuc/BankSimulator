using BankSimulator.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankSimulator.API.Data
{
    public interface IPaymantsRepository
    {
        Task Transfer(string recivingUser, string sendingUser, decimal cash);
        Task<bool> UserExists(string recivingUser);
    }
}
