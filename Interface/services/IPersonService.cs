using Interface.viewmodels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interface.services
{
    public interface IPersonService
    {
        Task<PersonViewModel> GetById(Guid id);
        Task<IEnumerable<PersonViewModel>> GetAll();
        Task<PersonViewModel> Add(PersonViewModel model);
        Task<PersonViewModel> Update(PersonViewModel model);
        Task<bool> Remove(PersonViewModel model);
    }
}
