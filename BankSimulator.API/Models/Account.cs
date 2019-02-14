using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankSimulator.API.Models
{
    public class Account
    {
        [Key]
        public int IdUser { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int? IdTH { get; set; }
        public int? IdWealth { get; set; }
        public int? IdUserInfo { get; set; }

        public virtual TransactionHistory TransactionHistory { get; set; }
        public virtual User_Info User_Info { get; set; }
        public virtual Wealth Wealth { get; set; }
    }
}
