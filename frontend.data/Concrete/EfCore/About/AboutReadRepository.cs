using frontend.data.Abstract;
using frontend.data.Context;
using frontend.entity;

namespace frontend.data.Concrete.EfCore
{
    public class AboutReadRepository : ReadRepository<About>, IAboutReadRepository
    {
        public AboutReadRepository(FrontEndDataDbContext context) : base(context)
        {
        }
    }
}
