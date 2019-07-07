using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace SpaApp.DataAccess.CosmosDb
{
    public interface ICosmosClientFactory
    {
        Task<CosmosClient> CreateAsync(
            string endpointUrl,
            string authorizationKey,
            string databaseName, 
            string collectionName, 
            string partitionKeyPath = null, 
            int throughput = 400, 
            string[] uniqueKeyPaths = null);
    }
}