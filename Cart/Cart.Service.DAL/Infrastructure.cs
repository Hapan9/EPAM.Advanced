using Azure.Identity;
using Cart.Service.DAL.Interfaces;
using Cart.Service.DAL.Repositories;
using Cart.Service.DAL.Repositories.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cart.Service.DAL
{
    public static class Infrastructure
    {
        public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddSingleton(sp =>
            {
                var clientOptions = new CosmosClientOptions
                {
                    ConnectionMode = ConnectionMode.Direct,
                    SerializerOptions = new CosmosSerializationOptions
                    {
                        PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
                    }
                };

                return new CosmosClient(
                    accountEndpoint: "https://az204otroian2.documents.azure.com:443/", new DefaultAzureCredential(), clientOptions);
            });

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICosmosDbProvider, CosmosDbProvider>();

            return services;
        }
    }
}
