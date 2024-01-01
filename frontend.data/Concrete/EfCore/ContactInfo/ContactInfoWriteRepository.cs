using frontend.data.Abstract;
using frontend.data.Context;
using frontend.entity;


namespace frontend.data.Concrete.EfCore
{
    public class ContactInfoWriteRepository : WriteRepository<ContactInfo>, IContactInfoWriteRepository
    {
        public ContactInfoWriteRepository(FrontEndDataDbContext context) : base(context)
        {
        }
    }
}
