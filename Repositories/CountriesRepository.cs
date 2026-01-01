using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Repositories
{
    public class CountriesRepository : ICountriesRepository
    {
        private readonly ContactsDbContext _dbContext;

        public CountriesRepository(ContactsDbContext contactsDb)
        {
            _dbContext = contactsDb;
        }

        public async Task<Country> AddCountry(Country country)
        {
            _dbContext.Countries.Add(country);
            await _dbContext.SaveChangesAsync();
            return country;
        }

        public async Task<List<Country>> GetAllCountries()
        {
            return await _dbContext.Countries.ToListAsync();
        }

        public async Task<Country?> GetCountryById(Guid id)
        {
            return await _dbContext.Countries.FirstOrDefaultAsync(temp => temp.CountryId == id);
        }

        public async Task<Country?> GetCountryByName(string countryname)
        {
            return await _dbContext.Countries.FirstOrDefaultAsync(temp => temp.CountryName == countryname);
        }
    }
}
