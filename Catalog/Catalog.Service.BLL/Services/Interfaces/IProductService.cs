using Catalog.Service.BLL.Dto;

namespace Catalog.Service.BLL.Services.Interfaces
{
    internal interface IProductService
    {
        Task CreateAsync(ProductDto dto, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<ProductDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task UpdateAsync(Guid id, ProductDto dto, CancellationToken cancellationToken);
    }
}
