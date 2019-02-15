using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankSimulator.API.Dtos
{
    public class AccountDtos
    {
        [Required]
        public string Login { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 8 characters")]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Birthdate { get; set; }
        public int PhoneNumber { get; set; }
        public string LiveAddress { get; set; }
    }
}
