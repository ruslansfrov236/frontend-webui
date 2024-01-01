using frontend.data.Abstract;
using frontend.data.Context;
using frontend.entity;



namespace frontend.data.Concrete.EfCore
{
    public class AboutHeaderWriteRepository : WriteRepository<AboutHeader>, IAboutHeaderWriteRepository
    {
        public AboutHeaderWriteRepository(FrontEndDataDbContext context) : base(context)
        {
        }
    }
}
