using Catalog.Service.DAL.Entities;
using Catalog.Service.DAL.Repositories.Abstraction;
using Catalog.Service.DAL.Repositories.Interfaces;

namespace Catalog.Service.DAL.Repositories
{
    public sealed class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(CatalogContext catalogContext) : base(catalogContext)
        {
        }
    }
}
