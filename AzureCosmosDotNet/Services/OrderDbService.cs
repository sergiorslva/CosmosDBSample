using AzureCosmosDotNet.Models;
using AzureCosmosDotNet.Services.Interfaces;
using Microsoft.Azure.Cosmos;

namespace AzureCosmosDotNet.Services
{
    public class OrderDbService : IOrderDbService
    {
        private readonly string containerName = "customer";
        private readonly string partitionKey = "/customerId";

        private readonly ICosmoDBService cosmoDBService;

        public OrderDbService(ICosmoDBService cosmoDBService)
        {
            this.cosmoDBService = cosmoDBService;
        }

        public async Task<ItemResponse<OrderModel>> CreateOrderAsync(OrderModel order)
        {
            var container = await cosmoDBService.CreateContainerAsync(containerName, partitionKey);                                    
            return await container.CreateItemAsync<OrderModel>(order, new PartitionKey(order.CustomerId));
        }

        public Task<ItemResponse<OrderModel>> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderModel>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
