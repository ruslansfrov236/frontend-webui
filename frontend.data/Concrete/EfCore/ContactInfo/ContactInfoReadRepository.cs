

using frontend.data.Abstract;
using frontend.data.Context;
using frontend.entity;

namespace frontend.data.Concrete.EfCore
{
    public class ContactInfoReadRepository : ReadRepository<ContactInfo>, IContactInfoReadRepository
    {
        public ContactInfoReadRepository(FrontEndDataDbContext context) : base(context)
        {
        }
    }
}
