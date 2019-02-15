using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankSimulator.API.Dtos
{
    public class CreditParametersDtos
    {
        public decimal CreditAmount { get; set; }
        public string UserLogin { get; set; }
    }
}
