

using frontend.data.Abstract;
using frontend.data.Context;
using frontend.entity;

namespace frontend.data.Concrete.EfCore
{
    public class FeautersWriteRepository : WriteRepository<Feauters>, IFeautersWriteRepository
    {
        public FeautersWriteRepository(FrontEndDataDbContext context) : base(context)
        {
        }
    }
}
