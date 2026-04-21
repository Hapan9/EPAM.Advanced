using Cart.Service.DAL.Interfaces;
using Microsoft.Azure.Cosmos;

namespace Cart.Service.DAL
{
    public sealed class CosmosDbProvider : ICosmosDbProvider
    {
        private readonly CosmosClient _client;

        public CosmosDbProvider(CosmosClient client)
        {
            _client = client;
        }

        public Container GetContainer(string dbName, string containerName)
        {
            var db = _client.GetDatabase(dbName);
            return db.GetContainer(containerName);
        }
    }
}
