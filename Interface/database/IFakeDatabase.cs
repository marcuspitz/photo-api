using Interface.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interface.database
{
    public interface IFakeDatabase
    {
        Task<List<Person>> GetPersonEnitites();
    }
}
