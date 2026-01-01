using ServiceContracts.DTO;

namespace ServiceContracts
{
    /// <summary>
    /// Represents business logic for manipulating country entity
    /// </summary>
    public interface ICountriesService
    {
        /// <summary>
        /// Add the country object to the list of the country
        /// </summary>
        /// <param name="countryAddRequest"></param>
        /// <returns>the country that be added</returns>
        public Task<CountryResponse> AddCountry(CountryAddRequest countryAddRequest);

        /// <summary>
        /// Returns all the Countries
        /// </summary>
        /// <returns>The list of the country</returns>
        public Task<List<CountryResponse>> GetAllCountries();
        
        /// <summary>
        /// Return the Country by The given PersonId
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Matching country as country response object</returns>
        public Task<CountryResponse> GetCountryById(Guid? id);

    }
}
