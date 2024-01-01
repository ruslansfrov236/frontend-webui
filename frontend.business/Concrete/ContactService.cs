using frontend.business.Abstrations;
using frontend.business.Application.Dtos.Contact;
using frontend.data.Abstract;
using frontend.entity;
using Microsoft.EntityFrameworkCore;


namespace frontend.business.Concrete
{
    public class ContactService : IContactService
    {
        readonly private IContactReadRepository _contactReadRepository;
        readonly private IContactWriteRepository _contactWriteRepository;

        public ContactService(IContactReadRepository contactReadRepository, IContactWriteRepository contactWriteRepository)
        {
            _contactReadRepository = contactReadRepository;
            _contactWriteRepository = contactWriteRepository;
        }
        public async Task<bool> Create(CreateContactDto model)
        {
            Contact contact = new Contact()
            {
                TitleWork = model.TitleWork,
                FullName = model.FullName,
                Telephone = model.Telephone,

            };


            await _contactWriteRepository.AddAsync(contact);

            await _contactWriteRepository.SaveAsync();

            return true;



        }

        public async Task<bool> Delete(string id)
        {
            var contact = await _contactReadRepository.GetByIdAsync(id);
            if (contact == null) return false;

            _contactWriteRepository.Remove(contact);
           await  _contactWriteRepository.SaveAsync();
            return true;



         }

        public async Task<List<Contact>> GetAll()
        {
            List<Contact> contacts = await _contactReadRepository.GetAll().ToListAsync();

            return contacts;
        }

        public async Task<Contact> GetById(string id)
        => await _contactReadRepository.GetByIdAsync(id);

        public async Task<bool> Update(UpdateContactDto model)
        {
            var contact = await _contactReadRepository.GetByIdAsync(model.Id);
             if(contact == null) return false;  

             contact.TitleWork = model.TitleWork;
            contact.FullName = model.FullName;
            contact.Telephone = model.Telephone;
            _contactWriteRepository.Update(contact);   
            await _contactWriteRepository.SaveAsync();
            return true;

        }
    }
}
