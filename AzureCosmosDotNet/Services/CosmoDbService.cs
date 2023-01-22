using AzureCosmosDotNet.Services.Interfaces;
using Microsoft.Azure.Cosmos;

namespace AzureCosmosDotNet.Services
{
    public class CosmoDbService: ICosmoDBService
    {
        private string endpointUri = String.Empty;
        private string primaryKey = String.Empty;

        private CosmosClient? cosmosClient;
        private Database? database = null;
        private string databaseId = "az204Database";        

        public CosmoDbService(IConfiguration configuration)
        {            
            endpointUri = configuration.GetValue<string>("CosmoDB:endpointuri");
            primaryKey = configuration.GetValue<string>("CosmoDB:primarykey");
        }               

        private async Task Connect()
        {            
            this.cosmosClient = new CosmosClient(endpointUri, primaryKey);
            this.database = await this.cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);                        
        }

        public async Task<Container> CreateContainerAsync(string container, string partitionKey)
        {            
            await this.Connect();
            if(this.database != null)
            {                
                return await this.database.CreateContainerIfNotExistsAsync(container, partitionKey);
            }

            throw new Exception("Database not found");
        }       
    }
}
