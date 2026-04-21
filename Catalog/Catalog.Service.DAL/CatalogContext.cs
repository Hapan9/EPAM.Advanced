using Catalog.Service.DAL.Enteties;
using Catalog.Service.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Service.DAL
{
    public sealed class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogContext).Assembly);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<T> GetDbSet<T>() where T : class
        {
            return Set<T>();
        }
    }
}
