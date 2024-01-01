using frontend.business.Application.Dtos.Contact;
using frontend.business.Application.Dtos.ContactInfo;
using frontend.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.business.Abstrations
{
    public interface IContactService
    {
        Task<List<Contact>> GetAll();
        Task<Contact> GetById(string id);

        Task<bool> Create(CreateContactDto model);
        Task<bool> Update(UpdateContactDto model);
        Task<bool> Delete(string id);
    }
}
