using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    //Person Domain Model class
    public class Person
    {
        [Key] //Primary key
        public Guid Id { get; set; }
        [StringLength(50)] //nvarchar(50)
        public string? Name { get; set; }
        public string? Email { get; set; }
        [StringLength(50)]
        public string? Address { get; set; }
        [StringLength(10)]
        public string? Gender    { get; set; }
        //uniqueIdentifier
        public Guid CountryId { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? RecieveNewsletter { get; set; }

        public Country country { get; set; } //navigation property
    }
}
