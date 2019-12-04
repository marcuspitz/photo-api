using AutoMapper;
using Interface.database;
using Interface.models;
using Interface.repository;
using Interface.services;
using Interface.viewmodels;
using Microsoft.Extensions.DependencyInjection;
using Repository.context;
using Repository.repository;
using Service.person;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.bootstrapper
{
    public static class Bootstrapper
    {
        public static void Register(IServiceCollection service)
        {
            #region Mapper           
            service.AddSingleton<IMapper>(new Mapper(new MapperConfiguration(mapper => {
                ViewModelToModel(mapper);
                ModelToViewModel(mapper);
            })
            ));
            #endregion

            #region Application
            #endregion

            #region Services
            service.AddScoped<IPersonService, PersonService>();
            #endregion

            #region Repositories
            service.AddScoped<IPersonRepository, PersonRepository>();
            #endregion

            #region Database
            service.AddSingleton<IFakeDatabase, FakeDatabase>();
            #endregion

            #region Utils

            #endregion
        }

        private static void ViewModelToModel(IMapperConfigurationExpression mapper)
        {            
            mapper.CreateMap<PersonViewModel, Person>();            
        }

        private static void ModelToViewModel(IMapperConfigurationExpression mapper)
        {
            mapper.CreateMap<Person, PersonViewModel>();
        }
    }
}
