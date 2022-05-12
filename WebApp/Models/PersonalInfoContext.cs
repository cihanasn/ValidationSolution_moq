using Microsoft.EntityFrameworkCore;
using System;

namespace WebApp.Models
{
    public class PersonalInfoContext : DbContext
    {
        public PersonalInfoContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasData
                (
                 new Person
                 {
                     Id = Guid.NewGuid(),
                     Name = "Cihan",
                     Surname = "ASAN",
                     Age = 23
                 },
                 new Person
                 {
                     Id = Guid.NewGuid(),
                     Name = "Mike",
                     Surname = "Anderson",
                     Age = 35
                 }
                );
        }

        public DbSet<Person>? People { get; set; }
    }
}
