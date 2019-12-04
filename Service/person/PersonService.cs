using AutoMapper;
using Interface.models;
using Interface.repository;
using Interface.services;
using Interface.utils;
using Interface.viewmodels;
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task<PersonViewModel> Add(PersonRequestViewModel model)
        {
            if (model.Id == null || model.Id.Equals(Guid.Empty))
                model.Id = Guid.NewGuid();
            var fullPath = await this.PersistFile(model);
            var person = new Person()
            {
                Id = model.Id,
                Age = model.Age,
                FirstName = model.FirstName,
                Gender = model.Gender,
                LastName = model.LastName,
                PicturePath = fullPath
            };
            var dbModel = await _repository.Add(person);
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
        
        public async Task<FileStream> GetPictureById(Guid id)
        {
            var dbModel = await _repository.GetById(id);
            if (dbModel != null)
            {
                return new FileStream(dbModel.PicturePath, FileMode.Open);
            }                
            return null;
        }

        public async Task<bool> Remove(Guid id)
        {
            return await _repository.Delete(id);
        }

        public async Task<PersonViewModel> Update(PersonRequestViewModel model)
        {
            var fullPath = await this.PersistFile(model);

            var person = new Person()
            {
                Id = model.Id,
                Age = model.Age,
                FirstName = model.FirstName,
                Gender = model.Gender,
                LastName = model.LastName,
                PicturePath = fullPath
            };
            var dbModel = await _repository.Update(person);
            return _mapper.Map<PersonViewModel>(dbModel);
        }

        private async Task<string> PersistFile(PersonRequestViewModel model)
        {
            if (!Directory.Exists(Utils.TEMP_FILE_PATH))
            {
                Directory.CreateDirectory(Utils.TEMP_FILE_PATH);
            }
            var fullPath = Path.Combine(Utils.TEMP_FILE_PATH, model.Id + "-" + model.Picture.FileName);
            var stream = new FileStream(fullPath, FileMode.Create);
            try
            {
                await model.Picture.CopyToAsync(stream);
            }
            finally
            {
                stream.Close();
            }
            return fullPath;
        }

    }
}
