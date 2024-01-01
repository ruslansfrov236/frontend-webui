using frontend.business.Application.Dtos.AboutHeader;
using frontend.business.Application.Dtos.Contact;
using frontend.business.Application.Dtos.ContactHeader;
using frontend.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.business.Abstrations
{
    public interface IContactHeaderService
    {
        Task<List<ContactHeader>> GetAll();
        Task<ContactHeader> GetById(string id);

        Task<bool> Create(CreateContactHeaderDto model);
        Task<bool> Update(UpdateContactHeaderDto model);
        Task<bool> Delete(string id);
    }
}
