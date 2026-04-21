using Microsoft.Azure.Cosmos;

namespace Cart.Service.DAL.Interfaces
{
    public interface ICosmosDbProvider
    {
        Container GetContainer(string dbName, string containerName);
    }
}
