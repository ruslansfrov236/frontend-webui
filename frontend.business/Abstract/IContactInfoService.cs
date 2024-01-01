using frontend.business.Application.Dtos.ContactInfo;
using frontend.entity;

namespace frontend.business.Abstrations
{
    public interface IContactInfoService
    {
        Task<List<ContactInfo>> GetAll();
        Task<ContactInfo> GetById(string id);

        Task<bool> Create(CreateContactInfoDto model);
        Task<bool> Update(UpdateContactInfoDto model);
        Task<bool> Delete(string id);
    }
}
