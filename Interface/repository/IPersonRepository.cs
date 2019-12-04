using Interface.models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interface.repository
{
    public interface IPersonRepository
    {
        Task<Person> GetById(Guid id);
        Task<IEnumerable<Person>> GetAll();
        Task<Person> Add(Person model);
        Task<Person> Update(Person model);
        Task<bool> Delete(Guid id);
    }
}
