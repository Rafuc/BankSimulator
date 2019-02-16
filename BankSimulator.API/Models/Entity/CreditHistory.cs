using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankSimulator.API.Models.Entity
{
    public class CreditHistory
    {
        [Key]
        public int IDCredit { get; set; }
        public decimal CreditAmmount { get; set; }
        public string Date { get; set; }
        public int RateOfIntrest { get; set; }
        public string CreditPaymentTime { get; set; }
        public decimal RemainingCredit { get; set; }
    }
}
