using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankSimulator.API.Dtos
{
    public class TransferDataDtos
    {
        public decimal Cash { get; set; }
        public string recivingUser { get; set; }
        public string sendingUser { get; set; }
    }
}
