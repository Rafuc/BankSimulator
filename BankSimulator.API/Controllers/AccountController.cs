using System.Linq;
using System.Threading.Tasks;
using BankSimulator.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankSimulator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly DataContext _dataContext;

        public AccountController(DataContext datacontext)
        {
            _dataContext = datacontext;
        }

        [HttpGet]
        public async Task<ActionResult> GetAccounts()
        {
            var accounts = await _dataContext.Accounts.ToListAsync();

            return Ok(accounts);
        }
    }
}