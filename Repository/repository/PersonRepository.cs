using Interface.database;
using Interface.models;
using Interface.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IFakeDatabase _database;
        public PersonRepository(IFakeDatabase database)
        {
            _database = database;
        }

        public async Task<Person> Add(Person model)
        {            
            var entities = await this._database.GetPersonEnitites();
            if (entities.Count(m => m.Id.Equals(model.Id)) > 0)
            {
                throw new Exception("Registro já existente");
            }
            else
            {
                entities.Add(model);
            }
            return model;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entities = await this._database.GetPersonEnitites();
            var obj = entities.FirstOrDefault(m => m.Id.Equals(id));
            if (obj == null)
            {
                throw new Exception("Registro não encontrado para remoção");
            }
            else
            {
                entities.Remove(obj);                
            }
            return true;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await this._database.GetPersonEnitites();
        }

        public async Task<Person> GetById(Guid id)
        {
            var entities = await this._database.GetPersonEnitites();
            return entities.FirstOrDefault(p => p.Id.Equals(id));
        }

        public async Task<Person> Update(Person model)
        {
            var entities = await this._database.GetPersonEnitites();
            var obj = entities.FirstOrDefault(m => m.Id.Equals(model.Id));
            if (obj == null)
            {
                throw new Exception("Registro não encontrado para atualização");
            }
            else
            {
                entities.Remove(obj);
                entities.Add(model);
            }
            return model;
        }
    }
}
