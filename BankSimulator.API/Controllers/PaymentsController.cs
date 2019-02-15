using Microsoft.AspNetCore.Mvc;
using BankSimulator.API.Dtos;
namespace BankSimulator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : Controller
    {
        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer(TransferDataDtos sendData)
        {
            decimal sendingMoney = sendData.moneyToSend; 
            string sendingUser = sendData.sendingUser;
            string receivingUser = sendData.receivingUser;
            
            
        }
    }
}