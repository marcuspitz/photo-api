using Interface.viewmodels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Interface.services
{
    public interface IPersonService
    {
        Task<PersonViewModel> GetById(Guid id);
        Task<FileStream> GetPictureById(Guid id);
        Task<IEnumerable<PersonViewModel>> GetAll();
        Task<PersonViewModel> Add(PersonRequestViewModel model);
        Task<PersonViewModel> Update(PersonRequestViewModel model);
        Task<bool> Remove(Guid id);
    }
}
