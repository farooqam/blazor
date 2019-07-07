using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace SpaApp.DataAccess.CosmosDb
{
    public interface ICosmosDbInitializer
    {
        Task<CosmosClient> InitializeAsync(
            string endpointUrl,
            string authorizationKey,
            string databaseName, 
            string collectionName, 
            string partitionKeyPath = null, 
            int throughput = 400, 
            string[] uniqueKeyPaths = null);
    }
}