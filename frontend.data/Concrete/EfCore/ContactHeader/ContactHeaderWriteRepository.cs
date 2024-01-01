using frontend.data.Abstract;
using frontend.data.Context;
using frontend.entity;


namespace frontend.data.Concrete.EfCore
{
    public class ContactHeaderWriteRepository : WriteRepository<ContactHeader>, IContactHeaderWriteRepository
    {
        public ContactHeaderWriteRepository(FrontEndDataDbContext context) : base(context)
        {
        }
    }
}
