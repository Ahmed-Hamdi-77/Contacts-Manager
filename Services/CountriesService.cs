using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;
using System.Security.AccessControl;
using System.Threading.Tasks;
namespace Services
{
    public class CountriesService : ICountriesService
    {
        private readonly ICountriesRepository _contriesRepositories;

        public CountriesService(ICountriesRepository countriesRepository)
        {
            _contriesRepositories = countriesRepository;
           
        }
        public async Task<CountryResponse> AddCountry(CountryAddRequest countryAddRequest)
        {
            //Validate if AddRequest is null
            if (countryAddRequest is null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }

            //Validate if CountryName is null
            if (countryAddRequest.CountryName is null)
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }

            //Validate if the give Country name is duplicated 
            if (await _contriesRepositories.GetCountryByName(countryAddRequest.CountryName) is not null)
            {
                throw new ArgumentException("The given Country name is duplicated");
            }

            // Convert CountryAddRequest to Country object
            Country country = countryAddRequest.ToCountry();

            //Generate a new GUID id
            country.CountryId = Guid.NewGuid();

            // Add the Country to Countries
            await _contriesRepositories.AddCountry(country);
            
            // Convert Country object to Country response object and return it
            return country.ToCountryResponse();

        }

        public async Task<List<CountryResponse>> GetAllCountries()
        {
            var Countries= await _contriesRepositories.GetAllCountries();
            List<CountryResponse> countryResponses = new List<CountryResponse>();
            foreach (var Country in Countries)
            {
                
                countryResponses.Add(Country.ToCountryResponse());
            }
            return countryResponses;
        }

        public async Task<CountryResponse>? GetCountryById(Guid? id)
        {
            if (id is null)
            {
                return null;
            }

            Country? MatchecCountry =await _contriesRepositories.GetCountryById(id.Value);
            if (MatchecCountry == null)
                return null;

            return MatchecCountry.ToCountryResponse();
        }
    }
}
