using Catalog.Service.DAL;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Catalog.Service.Tests.IntegrationTests.Utils
{
    public sealed class BaseTestFixture
    {
        private readonly IServiceScope _serviceScope;

        public BaseTestFixture()
        {
            var build = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll<CatalogContext>();
                        services.RemoveAll<DbContextOptions<CatalogContext>>();

                        services.AddDbContext<CatalogContext>(c => c.UseInMemoryDatabase($"testDb"));
                    });
                });

            Client = build.CreateClient();

            _serviceScope = build.Services.CreateScope();
        }

        public HttpClient Client { get; }

        public CatalogContext Context => _serviceScope.ServiceProvider.GetRequiredService<CatalogContext>();
    }
}
