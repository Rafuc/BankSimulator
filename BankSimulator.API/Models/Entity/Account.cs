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
        public string Login { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Birthdate { get; set; }
        public int PhoneNumber { get; set; }
        public string LiveAddress { get; set; }
        public decimal Cash { get; set; }

        public int? IdTH { get; set; }
        public virtual TransactionHistory TransactionHistorys { get; set; }
    }
}
