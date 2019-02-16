using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankSimulator.API.Models
{
    public class TransactionHistory
    {
        [Key]
        public int IdTH { get; set; }
        public decimal MoneyBefore { get; set; }
        public decimal MoneyAfter { get; set; }
        public string TitleOfTransaction { get; set; }
        public int IdUser { get; set; }
    }
}
