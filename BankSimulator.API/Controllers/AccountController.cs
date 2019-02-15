using System.Linq;
using System.Threading.Tasks;
using BankSimulator.API.Data;
using BankSimulator.API.Dtos;
using BankSimulator.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankSimulator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAuthRepository _repo;

        public AccountController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public int liczba()
        {
            return 300;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AccountDtos accountDtos)
        {
            accountDtos.Login = accountDtos.Login.ToLower();

            if (await _repo.UserExists(accountDtos.Login))
                return BadRequest("Username already exists");

            var accountToCreate = new Account
            {
                Login = accountDtos.Login,
                Birthdate = accountDtos.Birthdate,
                Email = accountDtos.Email,
                LiveAddress = accountDtos.Email,
                PhoneNumber = accountDtos.PhoneNumber,
                Name = accountDtos.Name,
                Surname = accountDtos.Surname
            };

            var createdAccount = await _repo.Register(accountToCreate, accountDtos.Password);

            return StatusCode(201);
        }
    }
}