using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankSimulator.API.Models
{
    public class Wealth
    {
        [Key]
        public int IdWealth { get; set; }
        public decimal Cash { get; set; }
    }
}
