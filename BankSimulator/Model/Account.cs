using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankSimulator.Model
{
    class Account
    {
        [Key]
        public int IdUser { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LiveAddres { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime BirthDayDate { get; set; }
        public decimal Cash { get; set; }
    }
}
