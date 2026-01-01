using Entities;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// DTO That is used as return for the most of the Person Service methods
    /// </summary>
    public class PersonResponse
    {
        public Guid PersonId { get; set; }
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }
        public DateTime? BirthDate { get; set; }
        public double? Age { get; set; }
        public bool? RecieveNewsletter { get; set; }

        //Compare the Current object with the parameter object
        public override bool Equals(object? obj)
        {
            if (obj is PersonResponse response)
            {
                return (response.PersonId == this.PersonId && response.PersonName==this.PersonName && response.Email==this.Email&&
                    response.Address==this.Address && response.Gender==this.Gender && response.CountryId==this.CountryId&&
                    response.BirthDate==this.BirthDate && response.RecieveNewsletter==this.RecieveNewsletter);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public PersonUpdateRequest ToPersonUpdateRequest()
        {
            return new PersonUpdateRequest() { PersonId =PersonId, PersonName=PersonName,
            Email=Email,Address=Address,Gender=(GenderOptions)Enum.Parse(typeof(GenderOptions),Gender,true)
            ,CountryId=CountryId,RecieveNewsletter=RecieveNewsletter,BirthDate=BirthDate};
        }

    }
        public static class PersonExtension
        {
        // An extension method to convert an object of Person entity to PersonResponse object
            public static PersonResponse ToPersonResponse(this Person person )
            {
            // Person => PersonResponse
                return new PersonResponse {PersonId=person.Id, PersonName=person.Name, Email=person.Email, Address=person.Address,
                    Gender=person.Gender, CountryId=person.CountryId, BirthDate=person.BirthDate, RecieveNewsletter=person.RecieveNewsletter,
                Age=(person.BirthDate!=null)? Math.Round((DateTime.Now-person.BirthDate.Value).TotalDays/365.25) : null, CountryName=person.country?.CountryName};
            }
            
        }
}
