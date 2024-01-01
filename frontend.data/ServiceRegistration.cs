


using frontend.data.Abstract;
using frontend.data.Concrete.EfCore;
using frontend.data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace frontend.data
{
    public static class ServiceRegistration
    {
        public static void AppDataRegistration(this IServiceCollection services)
        {
            services.AddDbContext<FrontEndDataDbContext>(options =>
            {
                options.UseSqlServer(Configuration.ConnectionString);
            });
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IAboutHeaderReadRepository, AboutHeaderReadRepository>();
            services.AddScoped<IAboutHeaderWriteRepository, AboutHeaderWriteRepository>();
            services.AddScoped<IAboutReadRepository, AboutReadRepository>();
            services.AddScoped<IAboutWriteRepository, AboutWriteRepository>();
            services.AddScoped<IContactHeaderReadRepository, ContactHeaderReadRepository>();
            services.AddScoped<IContactHeaderWriteRepository, ContactHeaderWriteRepository>();
            services.AddScoped<IContactInfoReadRepository, ContactInfoReadRepository>();
            services.AddScoped<IContactInfoWriteRepository, ContactInfoWriteRepository>();
            services.AddScoped<IContactReadRepository, ContactReadRepository>();
            services.AddScoped<IContactWriteRepository , ContactWriteRepository>(); 
            services.AddScoped<IFilesReadRepository, FilesReadRepository>();
            services.AddScoped<IFilesWriteRepository, FilesWriteRepository>();
            services.AddScoped<IFeautersReadRepository, FeautersReadRepository>();
            services.AddScoped<IFeautersWriteRepository, FeautersWriteRepository>();    
            services.AddScoped<IRecentWriteRepository, RecentWriteRepository>();
            services.AddScoped<IRecentWriteRepository, RecentWriteRepository>();
            services.AddScoped<IPricingWriteRepository ,PricingWriteRepository>();
            services.AddScoped<IPricingReadRepository ,PricingReadRepository>();    
            services.AddScoped<IRecentReadRepository ,RecentReadRepository>();
            services.AddScoped<IRecentWriteRepository ,RecentWriteRepository>();
           
        }
    }
}
