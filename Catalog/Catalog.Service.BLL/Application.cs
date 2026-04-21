using Catalog.Service.BLL.Services;
using Catalog.Service.BLL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Service.BLL
{
    public static class Application
    {
        public static IServiceCollection AddApplication(
        this IServiceCollection services)
        {
            services.AddAutoMapper(m => m.AddMaps(typeof(Application).Assembly));

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
