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
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Birthdate { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string LiveAddress { get; set; }
    }
}
