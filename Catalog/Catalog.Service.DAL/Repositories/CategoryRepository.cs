using Catalog.Service.DAL.Enteties;
using Catalog.Service.DAL.Repositories.Abstraction;
using Catalog.Service.DAL.Repositories.Interfaces;

namespace Catalog.Service.DAL.Repositories
{
    public sealed class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(CatalogContext catalogContext) : base(catalogContext)
        {
        }
    }
}
