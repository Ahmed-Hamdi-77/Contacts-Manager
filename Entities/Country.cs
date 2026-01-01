using System.ComponentModel.DataAnnotations;

namespace Entities
{
    /// <summary>
    /// Domain Model class for country
    /// </summary>
    public class Country
    {
        [Key] //Primary key
        public Guid CountryId { get; set; }
        [StringLength(50)] //nvarchar(50)
        public string? CountryName { get; set; }

        public IEnumerable<Person> persons { get; set; }

    }
}
