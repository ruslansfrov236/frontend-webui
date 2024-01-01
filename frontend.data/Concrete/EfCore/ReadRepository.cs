


using frontend.data.Abstract;
using frontend.data.Context;
using frontend.entity.Customers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace frontend.data.Concrete.EfCore
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity 
    {

        readonly private FrontEndDataDbContext _context;

        public ReadRepository(FrontEndDataDbContext context)

        {
            _context = context;
        }

        private DbSet<T> Table =>_context.Set<T>();  
        public  IQueryable<T> GetAll(bool tracking = true)
        {
            var query =  Table.AsQueryable();

            if(!tracking)
                query= Table.AsNoTracking();

            return query;
        }

        public  async Task<T> GetByIdAsync(string id, bool tracking = true)
        { 
            var query =  Table.AsQueryable();

            if (!tracking)
                query =  Table.AsNoTracking();

            return await   query.FirstOrDefaultAsync(qr=>qr.Id==Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query =Table.AsQueryable();
            if(!tracking)
                query = Table.AsNoTracking();

            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();

            return  query.Where(method);
        }
    }
    
}
