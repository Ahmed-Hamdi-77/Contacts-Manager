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
    public class PersonsGetterService : IPersonsGetterService
    {
        private readonly  IPersonsRepository _personsRepository;
        private readonly ICountriesService? _countriesService;
        private readonly ILogger<PersonsGetterService> _logger;

        public PersonsGetterService(IPersonsRepository personsRepository,ICountriesService countriesService,ILogger<PersonsGetterService>logger)
        {

            _personsRepository = personsRepository;
            _countriesService = countriesService;
            _logger = logger;
        }

       
       
        public async Task<List<PersonResponse>> GetAllPersons()
        {
            _logger.LogInformation("GetAllPersons of the person service");
            var persons = await _personsRepository.GetAllPersons();

            return persons.Select(p => p.ToPersonResponse()).ToList();
        }

        public async Task<PersonResponse>? GetPersonByPersonId(Guid? id)
        {
            //Check if id is not null
            if (id is null)            
                return null;
            //Get the matched person 
            Person? person = await _personsRepository.GetPersonById(id.Value);
            //Convert the person object to PersonResponse object and return it
            return person.ToPersonResponse();

        }

        public async Task<List<PersonResponse>> GetFilteredPersons(string? SearchString, string SearchBy)
        {
            _logger.LogInformation("GetFilterdPersons of the person service");

            List<Person> persons = SearchBy switch

            {
                nameof(PersonResponse.PersonName) =>
                   await _personsRepository.GetFilteredPersons(temp =>
                   temp.Name.Contains(SearchString)),

                nameof(PersonResponse.Email) =>
                    await _personsRepository.GetFilteredPersons(temp =>
                    temp.Email.Contains(SearchString)),


                nameof(PersonResponse.BirthDate) =>
                     await _personsRepository.GetFilteredPersons(temp =>
                     temp.BirthDate.Value.ToString("dd mm yyyy").Contains(SearchString)),

                nameof(PersonResponse.Gender) =>
                    await _personsRepository.GetFilteredPersons(temp =>
                    temp.Gender.Contains(SearchString)),

                nameof(PersonResponse.CountryName) =>
                    await _personsRepository.GetFilteredPersons(temp =>
                    temp.country.CountryName.Contains(SearchString)),

                nameof(PersonResponse.Address) =>
                    await _personsRepository.GetFilteredPersons(temp =>
                    temp.Address.Contains(SearchString)),

                _ => await _personsRepository.GetAllPersons()
            };

            return persons.Select(temp=>temp.ToPersonResponse()).ToList();

        }
       
    }
}
