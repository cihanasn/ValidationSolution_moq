using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Contracts;
using WebApp.Models;

namespace WebApp.Repository
{
    public class PersonalInfoRepo : IPersonalInfoRepo
    {
        private readonly PersonalInfoContext _context;

        public PersonalInfoRepo(PersonalInfoContext context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetAll() => _context.People.ToList();

        public Person GetPerson(Guid id) => _context.People
            .SingleOrDefault(e => e.Id.Equals(id));

        public void CreatePerson(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
        }
    }
}
