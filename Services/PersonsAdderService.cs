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
    public class PersonsAdderService : IPersonsAdderService
    {
        private readonly  IPersonsRepository _personsRepository;
        private readonly ICountriesService? _countriesService;
        private readonly ILogger<PersonsAdderService> _logger;

        public PersonsAdderService(IPersonsRepository personsRepository,ICountriesService countriesService,ILogger<PersonsAdderService>logger)
        {

            _personsRepository = personsRepository;
            _countriesService = countriesService;
            _logger = logger;
        }

       
        public async Task<PersonResponse> AddPerson(PersonAddRequest? personAddRequest)
        {
            //Check that the personRequest is not null
            if (personAddRequest is null)
            {
                throw new ArgumentNullException(nameof(personAddRequest));
            }
            //Model Validation
            ValidationHelper.ModelValidation(personAddRequest);

            //Convert The personAddRequest object to Person object
            Person person= personAddRequest.ToPerson();

            //Create new GUID id
            person.Id=Guid.NewGuid();
            
            // Add it the list Person
            await _personsRepository.AddPerson(person);
            
            //Retrun as a PersonResponse object
            return person.ToPersonResponse();

        }
        
    }
}
