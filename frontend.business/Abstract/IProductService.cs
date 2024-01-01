
using frontend.business.Application.Dtos.Product;
using frontend.entity;

namespace frontend.business.Abstrations
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(string id);

        Task<bool> Create(CreateProductDto model);
        Task<bool> Update(UpdateProductDto model);
        Task<bool> Delete(string id);
    }
}
