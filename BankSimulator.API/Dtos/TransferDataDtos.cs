using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankSimulator.API.Dtos
{
    public class TransferDataDtos
    {
        public string sendingUser{get; set;}
        public string receivingUser{get; set;}
        public decimal moneyToSend{get; set;}
    }
}
