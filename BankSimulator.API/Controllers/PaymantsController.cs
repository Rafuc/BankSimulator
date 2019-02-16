using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankSimulator.API.Data;
using BankSimulator.API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BankSimulator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymantsController : Controller
    {
        private readonly IPaymantsRepository _repo;

        public PaymantsController(IPaymantsRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer(TransferDataDtos sendingData)
        {
            bool userExist = await _repo.UserExists(sendingData.RecivingUser);
            
            if(sendingData.Cash <= 0)
                BadRequest("You can't send less money than 1 PLN");

            if (!userExist)
                BadRequest("This user don't exists");

            await _repo.Transfer(sendingData.RecivingUser, sendingData.SendingUser, sendingData.Cash);

            return StatusCode(201);        
        }

        [HttpPost("credit")]
        public async Task<IActionResult> Credit(CreditParametersDtos CreditValue) 
        {
          await _repo.Credit(CreditValue.UserLogin, CreditValue.CreditAmount);

          return StatusCode(201);
        }

        [HttpGet("currentlyCash")]
        public async Task<IActionResult> CurrentlyCash(CheckMoney user)
        {
            var cash = await _repo.ReturnCurrentCash(user.UserName);

            return Ok(cash);
        }
    }
}