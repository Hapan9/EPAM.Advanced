using Cart.Service.BLL.Dtos;

namespace Cart.Service.BLL.Services.Interfaces
{
    public interface ICartService
    {
        Task AddProductAsync(Guid cartId, ProductDto productDto, CancellationToken cancellationToken);
        Task DeleteProductAsync(Guid cartId, int productId, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetAllProductsAsync(Guid cartId, CancellationToken cancellationToken);
    }
}
