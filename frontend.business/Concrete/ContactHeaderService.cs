using frontend.business.Abstrations;
using frontend.business.Application.Dtos.ContactHeader;
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
    public class ContactHeaderService : IContactHeaderService
    {

        readonly private IContactHeaderWriteRepository _contactHeaderWriteRepository;
        readonly private IContactHeaderReadRepository _contactHeaderReadRepository;
        readonly private IFileService _fileService;

        public ContactHeaderService(IContactHeaderReadRepository contactHeaderReadRepository, IFileService fileService, IContactHeaderWriteRepository contactHeaderWriteRepository)
        {

            _contactHeaderReadRepository = contactHeaderReadRepository;
            _contactHeaderWriteRepository = contactHeaderWriteRepository;
            _fileService = fileService;
        }
        public async Task<bool> Create(CreateContactHeaderDto model)
        {
            if (!_fileService.CheckSize(model.File, 80)) return false;

            if (!_fileService.IsImage(model.File)) return false;

            var newFile = await _fileService.UploadAsync(model.File);

            ContactHeader contact = new ContactHeader()
            {
                Title = model.Title,
                Content=model.Content,
                Description=model.Description,
                Link = model.Link,
                FilePath = newFile,
               

            };
            await _contactHeaderWriteRepository.AddAsync(contact);
            await _contactHeaderWriteRepository.SaveAsync();
            return true;

        }

        public async Task<bool> Delete(string id)
        {
            var contact = await _contactHeaderReadRepository.GetByIdAsync(id);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\img\\", contact.FilePath);

            _fileService.Delete(path);

            _contactHeaderWriteRepository.Remove(contact);

            await _contactHeaderWriteRepository.SaveAsync();

            return true;
        }

        public async Task<List<ContactHeader>> GetAll()
        {
            List<ContactHeader> contactHeaders = await _contactHeaderReadRepository.GetAll().ToListAsync();

            return contactHeaders;
        }

        public async Task<ContactHeader> GetById(string id)
        => await _contactHeaderReadRepository.GetByIdAsync(id);

        public async Task<bool> Update(UpdateContactHeaderDto model)
        {
            if (!_fileService.CheckSize(model.File, 80)) return false;


            var contact = await _contactHeaderReadRepository.GetByIdAsync(model.id);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\img\\", contact.FilePath);
              
            _fileService.Delete(path);

            if (!_fileService.IsImage(model.File)) return false;

            
            var newFile = await _fileService.UploadAsync(model.File);

            contact.Title = model.Title;
            contact.Description = model.Description;
            contact.Content = model.Content;
            contact.Link = model.Link;
            contact.FilePath = newFile;

            _contactHeaderWriteRepository.Update(contact);
            await _contactHeaderWriteRepository.SaveAsync();
            return true;
        }
    }
}
