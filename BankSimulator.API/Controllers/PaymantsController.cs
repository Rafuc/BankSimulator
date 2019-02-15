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
            decimal cash = sendingData.Cash;
            string recivingUser = sendingData.recivingUser;
            string sendingUser = sendingData.sendingUser;

            bool userExist = await _repo.UserExists(recivingUser);
            if (!userExist)
                BadRequest("This user don't exists");

            await _repo.Transfer(recivingUser, sendingUser, cash);

            return StatusCode(201);        
        }
    }
}