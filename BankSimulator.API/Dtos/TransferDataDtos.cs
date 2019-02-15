using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankSimulator.API.Dtos
{
    public class TransferDataDtos
    {
        public decimal Cash { get; set; }
        public string RecivingUser { get; set; }
        public string SendingUser { get; set; }
    }
}
