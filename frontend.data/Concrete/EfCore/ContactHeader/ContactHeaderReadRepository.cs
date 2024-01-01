

using frontend.data.Abstract;
using frontend.data.Context;
using frontend.entity;

namespace frontend.data.Concrete.EfCore
{
    public class ContactHeaderReadRepository : ReadRepository<ContactHeader>, IContactHeaderReadRepository
    {
        public ContactHeaderReadRepository(FrontEndDataDbContext context) : base(context)
        {
        }
    }
}
