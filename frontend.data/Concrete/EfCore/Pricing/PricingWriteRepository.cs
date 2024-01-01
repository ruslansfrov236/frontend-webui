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
    public class PricingWriteRepository : WriteRepository<Pricing>, IPricingWriteRepository
    {
        public PricingWriteRepository(FrontEndDataDbContext context) : base(context)
        {
        }
    }
}
