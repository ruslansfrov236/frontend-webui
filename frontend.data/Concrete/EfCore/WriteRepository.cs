using frontend.data.Abstract;
using frontend.data.Context;
using frontend.entity.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace frontend.data.Concrete.EfCore
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {

        readonly private FrontEndDataDbContext _context;

        public WriteRepository(FrontEndDataDbContext context)
        {
            _context= context;
        }

        private DbSet<T> Table => _context.Set<T>();
        public async Task<bool> AddAsync(T model)
        {
           EntityEntry<T> entity=await  Table.AddAsync(model);   

            return entity.State== EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> data)
        {
          await Table.AddRangeAsync(data);
            return true;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T entity = await Table.FindAsync(Guid.Parse(id));
            if (entity == null) return false;

            return Remove(entity);
          
        }
    

        public  bool RemoveRange(List<T> data)
        {
            Table.RemoveRange(data);
            return true;
        }

        public async Task<int> SaveAsync()
       => await _context.SaveChangesAsync();

        public  bool Update(T model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
