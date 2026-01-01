using ServiceContracts.DTO;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    
    public interface IPersonsAdderService
    {
        /// <summary>
        /// Add the country object to the list of the Persons
        /// </summary>
        /// <param name="personAddRequest"></param>
        /// <returns>Returns the same person details,
        /// along with newly generated PersonId</returns>
       Task<PersonResponse> AddPerson(PersonAddRequest? personAddRequest);
    
    }
}
