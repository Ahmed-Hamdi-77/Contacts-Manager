using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// DTO That is used as return for the most of the CountryService methods
    /// </summary>
    public class CountryResponse

    {
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is CountryResponse response )
            {
                return (response.CountryName==this.CountryName && response.CountryId==this.CountryId);
            }
            return false;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
    public static class CountryExtension
    {
        public static CountryResponse ToCountryResponse(this Country country)
        {
            return new CountryResponse {CountryId=country.CountryId,CountryName=country.CountryName };
        }
    }

}
