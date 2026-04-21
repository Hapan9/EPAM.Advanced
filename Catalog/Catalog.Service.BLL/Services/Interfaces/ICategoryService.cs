using Catalog.Service.BLL.Dto;

namespace Catalog.Service.BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryDto dto, CancellationToken cancellationToken);
        Task UpdateAsync(Guid id, CategoryDto dto, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<List<CategoryDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<CategoryDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
