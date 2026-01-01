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
    public class PersonsUpdaterService : IPersonsUpdaterService
    {
        private readonly  IPersonsRepository _personsRepository;
        private readonly ICountriesService? _countriesService;
        private readonly ILogger<PersonsUpdaterService> _logger;

        public PersonsUpdaterService(IPersonsRepository personsRepository,ICountriesService countriesService,ILogger<PersonsUpdaterService> logger)
        {

            _personsRepository = personsRepository;
            _countriesService = countriesService;
            _logger = logger;
        }

      
        public async Task<PersonResponse> UpdatePerson(PersonUpdateRequest? personUpdateRequest)
        {
            if (personUpdateRequest is null)
                throw new ArgumentNullException(nameof(personUpdateRequest));
            //Check validations
            ValidationHelper.ModelValidation(personUpdateRequest);
            Person UpdatedPerson=await _personsRepository.UpdatePerson(personUpdateRequest.ToPerson());
            //Convert person object to PersonResponse object
            return UpdatedPerson.ToPersonResponse();
        }

    }
}
