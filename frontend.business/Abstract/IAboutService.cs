using frontend.business.Application.Dtos.About;

using frontend.entity;


namespace frontend.business.Abstrations
{
    public interface IAboutService
    {
        Task<List<About>> GetAll();
        Task<About> GetById(string id);

        Task<bool> Create(CreateAboutDto model);
        Task<bool> Update(UpdateAboutDto model);
        Task<bool> Delete(string id);
    }
}
