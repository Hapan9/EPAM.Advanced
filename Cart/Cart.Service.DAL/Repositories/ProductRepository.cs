using Cart.Service.DAL.Entities;
using Cart.Service.DAL.Interfaces;
using Cart.Service.DAL.Repositories.Abstraction;
using Cart.Service.DAL.Repositories.Interfaces;
using Microsoft.Azure.Cosmos;
using System.Runtime.CompilerServices;

namespace Cart.Service.DAL.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {

        public ProductRepository(ICosmosDbProvider cosmosDbProvider) : base(cosmosDbProvider, "dbo", "Products")
        {

        }

        public async Task AddProductToCartAsync(Guid cartId, Product product, CancellationToken cancellationToken = default)
        {
            var container = GetContainer();
            await container.CreateItemAsync(product, new PartitionKey(cartId.ToString()), cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async IAsyncEnumerable<Product> GetProductsByCartIdAsync(Guid cartId, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            var container = GetContainer();
            var query = new QueryDefinition(@"SELECT * FROM p WHERE p.cartId = @cartId").WithParameter("@cartId", cartId);
            using var iterator = container.GetItemQueryIterator<Product>(queryDefinition: query, requestOptions: new QueryRequestOptions { PartitionKey = new PartitionKey(cartId.ToString()) });

            while (iterator.HasMoreResults)
            {
                var page = await iterator.ReadNextAsync(cancellationToken);

                foreach (var item in page)
                {
                    yield return item;
                }
            }
        }

        public async Task RemoveProductFromCartAsync(Guid cartId, int productId, CancellationToken cancellationToken = default)
        {
            var container = GetContainer();
            await container.DeleteItemAsync<Product>(productId.ToString(), new PartitionKey(cartId.ToString()), cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
