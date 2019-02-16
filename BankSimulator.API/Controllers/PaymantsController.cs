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
                return BadRequest("You can't send less money than 1 PLN");
                
            if (!userExist)
                return BadRequest("This user don't exists");

            if (sendingData.RecivingUser == sendingData.SendingUser)
                return BadRequest("You can't send to yourself");

            string endingStatus = await _repo.Transfer(sendingData.RecivingUser, sendingData.SendingUser, sendingData.Cash, sendingData.TitleOfTransaction);

            return Ok(endingStatus);        
        }

        [HttpPost("credit")]
        public async Task<IActionResult> Credit(CreditParametersDtos CreditValue) 
        {
            await _repo.Credit(CreditValue.UserId,CreditValue.CreditAmount,CreditValue.Date,CreditValue.RateOfIntrest,CreditValue.CreditPaymantTime,
                CreditValue.RemainingCredit);

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