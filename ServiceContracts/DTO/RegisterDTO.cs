using Microsoft.AspNetCore.Mvc;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Person name can't be empty")]
        public string? PersonName { get; set; }
        [Required(ErrorMessage = "Email can't be empty")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email should be a valid email")]
        [Remote(action: "IsEmailInUse", controller:"Account",ErrorMessage ="This email is alreade registered")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Phone can't be empty")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^01[0-9]*$" ,ErrorMessage ="You can only enter numbers from 0 to 9")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Password can't be empty")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Confirm Password can't be empty")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Confirm Password doesn't match the password")]
        public string? ConfirmPassword { get; set; }
        public UserTypeOptions UserType { get; set; }= UserTypeOptions.User;
    }
}
