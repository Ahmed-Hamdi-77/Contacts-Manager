using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class PersonsRepository : IPersonsRepository
    {
        private readonly ContactsDbContext _dbContext;
        private readonly ILogger<PersonsRepository> _logger;

        public PersonsRepository(ContactsDbContext contactsDb,ILogger<PersonsRepository> logger)
        {
            _dbContext = contactsDb;
            _logger = logger;
        }

        public async Task<Person> AddPerson(Person person)
        {
             _dbContext.Persons.Add(person);
            await _dbContext.SaveChangesAsync();
            return person;
        }

        public async Task<bool> DeletePersonByPersonId(Guid id)
        {
            _dbContext.Persons.Remove(_dbContext.Persons.FirstOrDefault(temp => temp.Id == id));
            int rowsNumber= await _dbContext.SaveChangesAsync();
            return rowsNumber>0;
        }

        public async Task<List<Person>> GetAllPersons()
        {
            return await _dbContext.Persons.Include("country").ToListAsync();
        }

        public async Task<List<Person>> GetFilteredPersons(Expression<Func<Person, bool>> predicate)
        {
            _logger.LogInformation("GetFilterdPersons of the person repository");
            return await _dbContext.Persons.Include("country")
                .Where(predicate).ToListAsync();
        }

        public async Task<Person?> GetPersonById(Guid id)
        {
            return await _dbContext.Persons.Include("country").FirstOrDefaultAsync(empty=>empty.Id==id);
        }

        public async Task<Person> UpdatePerson(Person person)
        {
            var matchedPerson=await _dbContext.Persons.Include("country").FirstOrDefaultAsync(temp=>temp.Id==person.Id);

            if (matchedPerson==null) 
                    return person;
            
            matchedPerson.Name = person.Name;
            matchedPerson.Address = person.Address;
            matchedPerson.Email = person.Email;
            matchedPerson.Gender = person.Gender;
            matchedPerson.BirthDate = person.BirthDate;
            matchedPerson.CountryId = person.CountryId;
            matchedPerson.RecieveNewsletter = person.RecieveNewsletter;            
            await _dbContext.SaveChangesAsync();
            return matchedPerson;
        }
    }
}
