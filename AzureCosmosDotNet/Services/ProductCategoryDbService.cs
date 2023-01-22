using AzureCosmosDotNet.Models;
using AzureCosmosDotNet.Services.Interfaces;
using Microsoft.Azure.Cosmos;

namespace AzureCosmosDotNet.Services
{
    public class ProductCategoryDbService : IProductCategoryDbService
    {
        private readonly string containerName = "product-category";
        private readonly string partitionKey = "/type";

        private readonly ICosmoDBService cosmoDBService;

        public ProductCategoryDbService(ICosmoDBService cosmoDBService)
        {
            this.cosmoDBService = cosmoDBService;
        }

        public async Task<ItemResponse<ProductCategoryModel>> DeleteItemAsync(string id)
        {
            var container = await cosmoDBService.CreateContainerAsync(containerName, partitionKey);
            return await container.DeleteItemAsync<ProductCategoryModel>(id, partitionKey: new PartitionKey("category"));
        }

        public async Task<IEnumerable<ProductCategoryModel>> GetItemSAsync()
        {
            List<ProductCategoryModel> categoryList = new List<ProductCategoryModel>();

            var container = await cosmoDBService.CreateContainerAsync(containerName, partitionKey);

            var query = new QueryDefinition(
                 query: "SELECT * FROM c WHERE c.type = @type")                
                .WithParameter("@type", "category");

            var customersFeed = container.GetItemQueryIterator<ProductCategoryModel>
                (
                    queryDefinition: query
                );

            while (customersFeed.HasMoreResults)
            {
                FeedResponse<ProductCategoryModel> response = await customersFeed.ReadNextAsync();
                foreach (ProductCategoryModel item in response)
                {
                    categoryList.Add(item);
                }
            }

            return categoryList;
        }

        public async Task<ItemResponse<ProductCategoryModel>> GetItemAsync(string id)
        {
            var container = await cosmoDBService.CreateContainerAsync(containerName, partitionKey);
            return await container.ReadItemAsync<ProductCategoryModel>(id, partitionKey: new PartitionKey("category"));
        }

        public async Task<ItemResponse<ProductCategoryModel>> UpsertItemAsync(ProductCategoryModel category)
        {
            var container = await cosmoDBService.CreateContainerAsync(containerName, partitionKey);
            return await container.UpsertItemAsync<ProductCategoryModel>
                (
                    category, 
                    new PartitionKey("category")
                );
        }
    }
}
