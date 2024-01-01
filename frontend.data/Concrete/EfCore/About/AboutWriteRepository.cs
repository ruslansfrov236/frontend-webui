using frontend.data.Abstract;
using frontend.data.Context;
using frontend.entity;


namespace frontend.data.Concrete.EfCore
{
    public class AboutWriteRepository : WriteRepository<About>, IAboutWriteRepository
    {
        public AboutWriteRepository(FrontEndDataDbContext context) : base(context)
        {
        }
    }
}
