using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email can't be empty")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email should be a valid email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password can't be empty")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
