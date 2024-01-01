

using frontend.data.Abstract;
using frontend.data.Concrete.EfCore;
using frontend.data.Context;
using frontend.entity;

namespace frontend.data.Concrete.EfCore
{
    public class ProductWriteRepository: WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(FrontEndDataDbContext context) : base(context)
        {
        }
    }
}
