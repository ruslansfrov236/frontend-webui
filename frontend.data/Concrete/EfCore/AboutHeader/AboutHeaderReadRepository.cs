using frontend.data.Abstract;
using frontend.data.Context;
using frontend.entity;

namespace frontend.data.Concrete.EfCore
{
    public class AboutHeaderReadRepository : ReadRepository<AboutHeader>, IAboutHeaderReadRepository
    {
        public AboutHeaderReadRepository(FrontEndDataDbContext context) : base(context)
        {
        }
    }
}
