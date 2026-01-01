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
    public class PersonsSorterService : IPersonsSorterService
    {
        private readonly  IPersonsRepository _personsRepository;
        private readonly ICountriesService? _countriesService;
        private readonly ILogger<PersonsSorterService> _logger;

        public PersonsSorterService(IPersonsRepository personsRepository,ICountriesService countriesService,ILogger<PersonsSorterService> logger)
        {

            _personsRepository = personsRepository;
            _countriesService = countriesService;
            _logger = logger;
        }

       
       
        public  List<PersonResponse> GetSortedPersons(List<PersonResponse> Allpersons, string sortedBy, SortOrderOptions SortOrder)
        {
            _logger.LogInformation("GetSortedPersons of the person service");

            if (string.IsNullOrEmpty(sortedBy))
                return Allpersons;


            List<PersonResponse> SortedPersons = (sortedBy, SortOrder)
                switch
            {
                (nameof(PersonResponse.PersonName), SortOrderOptions.Asc)
                => Allpersons.OrderBy(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.PersonName), SortOrderOptions.Desc)
               => Allpersons.OrderByDescending(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.CountryName), SortOrderOptions.Asc)
                => Allpersons.OrderBy(temp => temp.CountryName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.CountryName), SortOrderOptions.Desc)
               => Allpersons.OrderByDescending(temp => temp.CountryName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Address), SortOrderOptions.Asc)
                => Allpersons.OrderBy(temp => temp.Address, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Address), SortOrderOptions.Desc)
               => Allpersons.OrderByDescending(temp => temp.Address, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.BirthDate), SortOrderOptions.Asc)
                => Allpersons.OrderBy(temp => temp.BirthDate).ToList(),

                (nameof(PersonResponse.BirthDate), SortOrderOptions.Desc)
               => Allpersons.OrderByDescending(temp => temp.BirthDate).ToList(),

                (nameof(PersonResponse.Age), SortOrderOptions.Asc)
               => Allpersons.OrderBy(temp => temp.Age).ToList(),

                (nameof(PersonResponse.Age), SortOrderOptions.Desc)
               => Allpersons.OrderByDescending(temp => temp.Age).ToList(),

                (nameof(PersonResponse.Email), SortOrderOptions.Asc)
               => Allpersons.OrderBy(temp => temp.Email,StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Email), SortOrderOptions.Desc)
               => Allpersons.OrderByDescending(temp => temp.Email, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.RecieveNewsletter), SortOrderOptions.Asc)
               => Allpersons.OrderBy(temp => temp.RecieveNewsletter).ToList(),

                (nameof(PersonResponse.RecieveNewsletter), SortOrderOptions.Desc)
               => Allpersons.OrderByDescending(temp => temp.RecieveNewsletter).ToList(),

                (nameof(PersonResponse.Gender), SortOrderOptions.Asc)
               => Allpersons.OrderBy(temp => temp.Gender, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Gender), SortOrderOptions.Desc)
               => Allpersons.OrderByDescending(temp => temp.Gender, StringComparer.OrdinalIgnoreCase).ToList(),

              _ => Allpersons
            };

            return SortedPersons;
        }
       
    }
}
