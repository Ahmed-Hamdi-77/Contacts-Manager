using Entities;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    //Acts as a DTO for inserting a new person
    public class PersonAddRequest
    {
        [Required(ErrorMessage ="Person name can't be blank")]
        public string? PersonName { get; set; }
        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage ="Email should be a valid email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Address can't be blank")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Gender should be selected")]
        public GenderOptions? Gender { get; set; }
        public Guid CountryId { get; set; }
        [Range(typeof(DateTime),"1/1/1900","1/1/2025",ErrorMessage = "Birth date should be between 1/1/1900 and 1/1/2025")]
        [Required(ErrorMessage = "BirthDate can't be blank")]
        public DateTime? BirthDate { get; set; }
        public bool? RecieveNewsletter { get; set; }

        public Person ToPerson()
        {
            return new Person {Name=PersonName ,Email=Email ,Address=Address,       
            Gender=Gender.ToString() ,CountryId=CountryId ,BirthDate=BirthDate,
            RecieveNewsletter=RecieveNewsletter};
        }
    }
}
