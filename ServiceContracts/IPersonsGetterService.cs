using ServiceContracts.DTO;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
   
    public interface IPersonsGetterService
    {
        
        /// <summary>
        /// Returns All Persons
        /// </summary>
        /// <returns>Returns a list of objects of PersonResponse type</returns>
        Task<List<PersonResponse>> GetAllPersons();

        /// <summary>
        /// Retruns a person by person id 
        /// </summary>
        /// <returns>Rutruns a mathced person with PersonId as a PersonResponse object</returns>
        Task<PersonResponse>? GetPersonByPersonId(Guid? id);

        Task<List<PersonResponse>> GetFilteredPersons(string? SearchString, string SearchBy);

        
    }
}
