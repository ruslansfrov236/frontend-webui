using frontend.business.Application.Dtos.AboutHeader;
using frontend.entity;
namespace frontend.business.Abstrations
{
    public interface IAboutHeaderService
    {
        Task<List<AboutHeader>> GetAll();
        Task<AboutHeader> GetById(string id);

        Task<bool> Create(CreateAboutHeaderDto model);
        Task<bool> Update(UpdateAboutHeaderDto model);
        Task<bool> Delete(string id);
    }
}
