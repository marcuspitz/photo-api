using Interface.database;
using Interface.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.context
{
    public class FakeDatabase : IFakeDatabase
    {
        private List<Person> personEntities { get; set; }
        public Task<List<Person>> GetPersonEnitites()
        {
            if (this.personEntities == null)
            {
                this.personEntities = new List<Person>();
            }
            return Task.FromResult<List<Person>>(this.personEntities);
        }
    }
}
