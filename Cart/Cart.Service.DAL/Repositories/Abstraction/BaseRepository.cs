using Cart.Service.DAL.Interfaces;
using Microsoft.Azure.Cosmos;

namespace Cart.Service.DAL.Repositories.Abstraction
{
    public abstract class BaseRepository
    {
        private readonly ICosmosDbProvider _cosmosDbProvider;
        private readonly string _dbName;
        private readonly string _containerName;

        protected BaseRepository(ICosmosDbProvider cosmosDbProvider, string dbName, string containerName)
        {
            _cosmosDbProvider = cosmosDbProvider;
            _dbName = dbName;
            _containerName = containerName;
        }

        protected Container GetContainer() => _cosmosDbProvider.GetContainer(_dbName, _containerName);
    }
}
