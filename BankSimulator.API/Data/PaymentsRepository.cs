using System.Threading.Tasks;
using BankSimulator.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BankSimulator.API.Data
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly DataContext _context;
        public PaymentsRepository(DataContext context)
        {
            _context = context;
        }
        public Task<Account> Transfer(decimal transfer, string userSend, string userGet, string titleOfTransfer)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UserExists(string username)
        {
            if(await _context.Accounts.AnyAsync(x => x.Login == username))
                return true;
                
            return false;
        }
    }
}