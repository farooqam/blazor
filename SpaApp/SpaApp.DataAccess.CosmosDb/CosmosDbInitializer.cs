﻿using Microsoft.Azure.Cosmos;
using System.Threading.Tasks;

namespace SpaApp.DataAccess.CosmosDb
{
    public class CosmosClientFactory : ICosmosClientFactory
    {
        public async Task<CosmosClient> CreateAsync(
            string endpointUrl,
            string authorizationKey,
            string databaseName,
            string collectionName,
            string partitionKeyPath = null,
            int throughput = 400,
            string[] uniqueKeyPaths = null)
        {
            CosmosClient cosmosClient = new CosmosClient(endpointUrl, authorizationKey);
            Database database = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseName);

            ContainerResponse container = await database.CreateContainerIfNotExistsAsync(
                id: collectionName,
                partitionKeyPath: partitionKeyPath,
                throughput: throughput);

            if (uniqueKeyPaths != null && uniqueKeyPaths.Length > 0)
            {
                UniqueKey uniqueKey = new UniqueKey();

                foreach (string uniqueKeyPath in uniqueKeyPaths)
                {
                    if (!string.IsNullOrWhiteSpace(uniqueKeyPath))
                    {
                        uniqueKey.Paths.Add(uniqueKeyPath);
                    }
                }

                UniqueKeyPolicy uniqueKeyPolicy = new UniqueKeyPolicy();
                uniqueKeyPolicy.UniqueKeys.Add(uniqueKey);

                container.Resource.UniqueKeyPolicy = uniqueKeyPolicy;
            }

            return cosmosClient;
        }
    }
}
