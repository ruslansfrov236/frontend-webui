using frontend.data.Abstract;
using frontend.data.Concrete.EfCore;
using frontend.data.Context;
using frontend.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.data.Concrete.EfCore
{
    internal class ContactWriteRepository : WriteRepository<Contact>, IContactWriteRepository
    {
        public ContactWriteRepository(FrontEndDataDbContext context) : base(context)
        {
        }
    }
}
