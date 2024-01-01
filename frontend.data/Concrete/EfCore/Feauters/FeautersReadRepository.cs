



using frontend.data.Abstract;
using frontend.data.Context;
using frontend.entity;

namespace frontend.data.Concrete.EfCore
{

    public class FeautersReadRepository : ReadRepository<Feauters>, IFeautersReadRepository
    {
        public FeautersReadRepository(FrontEndDataDbContext context) : base(context)
        {
        }
    }
}
