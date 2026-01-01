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
    //Acts as a DTO for updating an existing person
    public class PersonUpdateRequest
    {
        [Required(ErrorMessage ="Id can't be blank")]
        public Guid PersonId { get; set; }
        [Required(ErrorMessage = "Person name can't be blank")]
        public string? PersonName { get; set; }
        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage = "Email should be a valid email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Address can't be blank")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Gender can't be blank")]
        public GenderOptions? Gender { get; set; }
        public Guid CountryId { get; set; }
        [Range(typeof(DateTime), "1/1/1900", "1/1/2025", ErrorMessage = "Birth date should be between 1/1/1900 and 1/1/2025")]
        public DateTime? BirthDate { get; set; }
        public bool? RecieveNewsletter { get; set; }

        /// <summary>
        /// Converts the current object of personAddRequest into a new
        /// object of Person type
        /// </summary>
        /// <returns>Returns a person object</returns>
        public Person ToPerson()
        {
            return new Person
            {
                Id = PersonId,
                Name = PersonName,
                Email = Email,
                Address = Address,
                Gender = Gender.ToString(),
                CountryId = CountryId,
                BirthDate = BirthDate,
                RecieveNewsletter = RecieveNewsletter
            };
        }
    }
}
