using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PersonsDeleterService : IPersonsDeleterService
    {
        private readonly  IPersonsRepository _personsRepository;
        private readonly ICountriesService? _countriesService;
        private readonly ILogger<PersonsDeleterService> _logger;

        public PersonsDeleterService(IPersonsRepository personsRepository,ICountriesService countriesService,ILogger<PersonsDeleterService>logger)
        {

            _personsRepository = personsRepository;
            _countriesService = countriesService;
            _logger = logger;
        }
              
        public async Task<bool> DeletePerson(Guid? id)
        {
            if (id is null)
                throw new ArgumentNullException(nameof(id));

            bool isDeleted = await _personsRepository.DeletePersonByPersonId(id.Value);

            return isDeleted;
        }
    }
}
