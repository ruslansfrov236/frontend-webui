using frontend.entity.Customers;
using frontend.entity;
using Microsoft.EntityFrameworkCore;

namespace frontend.data.Context
{
    public class FrontEndDataDbContext:DbContext
    {
        public FrontEndDataDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product>? Products { get; set; }
        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<ContactHeader>? ContactHeaders { get; set; }
        public DbSet<ContactInfo>? ContactInfo { get; set; }
        public DbSet<Pricing>? Pricing { get; set; }
        public DbSet<About>? Abouts { get; set; }
        public DbSet<AboutHeader>? AboutHeaders { get; set; }

        public DbSet<Files>? Files { get; set; }

        public DbSet<Feauters> Feauters { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {


            var datas = ChangeTracker
                 .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

