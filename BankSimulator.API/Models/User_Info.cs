using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankSimulator.API.Models
{
    public class User_Info
    {
        [Key]
        public int IdUserInfo { get; set; }
        public string Email { get; set; }
        public string Birthdate { get; set; }
        public int PhoneNumber { get; set; }
        public string LiveAddress { get; set; }
    }
}
