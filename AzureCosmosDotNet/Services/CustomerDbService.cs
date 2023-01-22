using AzureCosmosDotNet.Models;
using AzureCosmosDotNet.Services.Interfaces;
using Microsoft.Azure.Cosmos;

namespace AzureCosmosDotNet.Services
{
    public class CustomerDbService: ICustomerDbService
    {

        private readonly string containerName = "customer";
        private readonly string partitionKey = "/customerId";

        private readonly ICosmoDBService cosmoDBService;

        public CustomerDbService(ICosmoDBService cosmoDBService)
        {
            this.cosmoDBService = cosmoDBService;
        }

        public async Task<IEnumerable<CustomerModel>> GetItemsAsync()
        {
            List<CustomerModel> customerList = new List<CustomerModel>();

            var container = await cosmoDBService.CreateContainerAsync(containerName, partitionKey);

            var query = new QueryDefinition(query: "SELECT * FROM c WHERE c.type = @type AND c.Id = @id")
                .WithParameter("@id", partitionKey)
                .WithParameter("@type", "customer");

            var customersFeed = container.GetItemQueryIterator<CustomerModel>
                (                    
                    queryDefinition: query
                );

            while (customersFeed.HasMoreResults)
            {
                FeedResponse<CustomerModel> response = await customersFeed.ReadNextAsync();
                foreach (CustomerModel item in response)
                {
                    customerList.Add(item);                    
                }
            }

            return customerList;
        }

        public async Task<ItemResponse<CustomerModel>> GetItemAsync(string id)
        {            
            var container = await cosmoDBService.CreateContainerAsync(containerName, partitionKey);
            return await container.ReadItemAsync<CustomerModel>(id, partitionKey: new PartitionKey(id));            
        }

        public async Task<ItemResponse<CustomerModel>> DeleteItemAsync(string id)
        {
            var container = await cosmoDBService.CreateContainerAsync(containerName, partitionKey);
            return await container.DeleteItemAsync<CustomerModel>(id, partitionKey: new PartitionKey(id));
        }

        public async Task<ItemResponse<CustomerModel>> UpsertItemAsync(CustomerModel customer)
        {
            var container = await cosmoDBService.CreateContainerAsync(containerName, partitionKey);
            return await container.UpsertItemAsync<CustomerModel>(customer, new PartitionKey(customer.Id));
        }
    }
}
