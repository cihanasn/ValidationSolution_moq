using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Contracts
{
    public interface IPersonalInfoRepo
    {
        IEnumerable<Person> GetAll();
        Person GetPerson(Guid id);
        void CreatePerson(Person person);
    }
}
