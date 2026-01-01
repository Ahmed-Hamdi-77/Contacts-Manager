using ServiceContracts.DTO;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    
    public interface IPersonsDeleterService
    {
    /// <summary>
    /// Deletes the person with the specified identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the person to delete. If <see langword="null"/>, the operation will not delete any
    /// person.</param>
    /// <returns><see langword="true"/> if the person was successfully deleted; otherwise, <see langword="false"/>.</returns>
        Task<bool> DeletePerson(Guid? id);
    }
}
