using frontend.data.Abstract;
using frontend.data.Context;
using frontend.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.data.Concrete.EfCore
{
    public class RecentWriteRepository : WriteRepository<Recent>, IRecentWriteRepository
    {
        public RecentWriteRepository(FrontEndDataDbContext context) : base(context)
        {
        }
    }
}
