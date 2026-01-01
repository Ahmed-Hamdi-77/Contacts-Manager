using ServiceContracts.DTO;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    
    public interface IPersonsSorterService
    {
    
        /// <summary>
        /// Retruns Sorted list of persons
        /// </summary>
        /// <param name="Allpersons">Represent list of persons to sort</param>
        /// <param name="sortedBy">Name of the property (key), based on
        /// which the persons should be sorted</param>
        /// <param name="SortOrder">ASC or DESC</param>
        /// <returns>Returns a list of sorted persons as a PersonResponse</returns>
        List<PersonResponse> GetSortedPersons(List<PersonResponse> Allpersons, string sortedBy, SortOrderOptions SortOrder);

        
    }
}
