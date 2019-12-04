using AutoMapper;
using Interface.models;
using Interface.repository;
using Interface.services;
using Interface.viewmodels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.person
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;
        public PersonService(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PersonViewModel> Add(PersonViewModel model)
        {            
            var dbModel = await _repository.Add(_mapper.Map<Person>(model));
            return _mapper.Map<PersonViewModel>(dbModel);
        }

        public async Task<IEnumerable<PersonViewModel>> GetAll()
        {
            var dbEntities = await _repository.GetAll();
            return _mapper.Map<IEnumerable<PersonViewModel>>(dbEntities);
        }

        public async Task<PersonViewModel> GetById(Guid id)
        {
            var dbModel = await _repository.GetById(id);
            return _mapper.Map<PersonViewModel>(dbModel);
        }

        public async Task<bool> Remove(PersonViewModel model)
        {
            return await _repository.Delete(_mapper.Map<Person>(model));
        }

        public async Task<PersonViewModel> Update(PersonViewModel model)
        {
            var dbModel = await _repository.Update(_mapper.Map<Person>(model));
            return _mapper.Map<PersonViewModel>(dbModel);
        }
    }
}
