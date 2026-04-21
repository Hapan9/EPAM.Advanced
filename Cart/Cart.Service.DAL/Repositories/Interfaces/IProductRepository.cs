using Cart.Service.DAL.Entities;

namespace Cart.Service.DAL.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IAsyncEnumerable<Product> GetProductsByCartIdAsync(Guid cartId, CancellationToken cancellationToken = default);

        Task AddProductToCartAsync(Guid cartId, Product product, CancellationToken cancellationToken = default);

        Task RemoveProductFromCartAsync(Guid cartId, int productId, CancellationToken cancellationToken = default);
    }
}
