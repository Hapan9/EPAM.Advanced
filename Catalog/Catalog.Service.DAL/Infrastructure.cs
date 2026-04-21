using Catalog.Service.DAL.Repositories;
using Catalog.Service.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Service.DAL
{
    public static class Infrastructure
    {
        public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<CatalogContext>(opts =>
            {
                opts.UseSqlServer("Server=localhost,1433;Database=EPAM;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;");
            });

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
