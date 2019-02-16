using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankSimulator.API.Dtos
{
    public class CreditParametersDtos
    {
        public int UserId { get; set; }
        public decimal CreditAmount { get; set; }
        public string Date { get; set; }
        public int RateOfIntrest { get; set; }
        public string CreditPaymantTime { get; set; }
        public decimal RemainingCredit { get; set; }
    }
}
