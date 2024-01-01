using frontend.business.Abstrations;
using frontend.business.Application.Dtos.ContactInfo;
using frontend.data.Abstract;
using frontend.entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.business.Concrete
{
    public class ContactInfoService : IContactInfoService
    {
        readonly private IContactInfoReadRepository _contactInfoReadRepository;

        readonly private IContactInfoWriteRepository _contactInfoWriteRepository;

        public ContactInfoService(IContactInfoReadRepository contactInfoReadRepository, IContactInfoWriteRepository contactInfoWriteRepository)
        {

            _contactInfoReadRepository = contactInfoReadRepository;
            _contactInfoWriteRepository = contactInfoWriteRepository;
        }
        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ContactInfo>> GetAll()
        {
            List<ContactInfo> contacts = await _contactInfoReadRepository.GetAll().ToListAsync();

            return contacts;
        }

        public async Task<ContactInfo> GetById(string id)
        => await _contactInfoReadRepository.GetByIdAsync(id);

        public async Task<bool> Create(CreateContactInfoDto model)
        {
            ContactInfo contactInfo = new ContactInfo()
            {

                Title = model.Title,
                TitleText = model.TitleText,
                Description = model.Description,

            };
            await _contactInfoWriteRepository.AddAsync(contactInfo);
            await _contactInfoWriteRepository.SaveAsync();

            return true;
        }

        public async Task<bool> Update(UpdateContactInfoDto model)
        {
            var contactInfo = await _contactInfoReadRepository.GetByIdAsync(model.id);

            if (contactInfo == null) return false;
            contactInfo.Title = model.Title;
            contactInfo.Title=model.TitleText;
            contactInfo.Description = model.Description;
             _contactInfoWriteRepository.Update(contactInfo);
            await _contactInfoWriteRepository.SaveAsync();
            return true;
        }
    }
}
