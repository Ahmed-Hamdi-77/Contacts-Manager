using Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ContactsDbContext: IdentityDbContext<ApplicationUser,ApplicationRole,Guid>
    {
       
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Country> Countries { get; set; }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().ToTable("Countries");
            modelBuilder.Entity<Person>().ToTable("Persons");

            //seeding initial data
            string countriesString = System.IO.File.ReadAllText("Countries.json");
            List<Country>? Countries=System.Text.Json.JsonSerializer.Deserialize<List<Country>>(countriesString);
            foreach (var country in Countries)
                modelBuilder.Entity<Country>().HasData(country);

            string personsString = System.IO.File.ReadAllText("Persons.json");
            List<Person>? Persons = System.Text.Json.JsonSerializer.Deserialize<List<Person>>(personsString);
            foreach (var person in Persons)
                modelBuilder.Entity<Person>().HasData(person);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.country)
                .WithMany(c => c.persons)
                .HasForeignKey(p => p.CountryId)
                .IsRequired();          
        }       
    }
}
