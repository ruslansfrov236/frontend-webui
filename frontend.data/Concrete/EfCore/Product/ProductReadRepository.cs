using frontend.data.Abstract;
using frontend.data.Context;
using frontend.entity;



namespace frontend.data.Concrete.EfCore
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(FrontEndDataDbContext context) : base(context)
        {
        }
    }
}
