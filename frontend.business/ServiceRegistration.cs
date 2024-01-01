
using frontend.business.Abstract;
using frontend.business.Abstrations;
using frontend.business.Concrete;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;


namespace frontend.business
{
    public static class ServiceRegistration
    {
        public static void AddBusinessRegistration(this IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAboutHeaderService, AboutHeaderService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IContactInfoService, ContactInfoService>();
            services.AddScoped<IContactHeaderService, ContactHeaderService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IFeautersService, FeautersService>();
            services.AddScoped<IPricingService, PricingService>();
            services.AddScoped<IRecentService, RecentService>();
        }

    }
}
    