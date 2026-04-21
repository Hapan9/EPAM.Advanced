using Cart.Service.BLL.Services;
using Cart.Service.BLL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cart.Service.BLL
{
    public static class Application
    {
        public static IServiceCollection AddApplication(
        this IServiceCollection services)
        {
            services.AddAutoMapper(m => m.AddMaps(typeof(Application).Assembly));

            services.AddScoped<ICartService, CartService>();

            return services;
        }
    }
}
