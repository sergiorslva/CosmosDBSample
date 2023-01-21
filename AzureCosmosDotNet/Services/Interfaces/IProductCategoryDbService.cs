using AzureCosmosDotNet.Models;
using Microsoft.Azure.Cosmos;

namespace AzureCosmosDotNet.Services.Interfaces
{
    public interface IProductCategoryDbService
    {        
        Task<IEnumerable<ProductCategoryModel>> GetItemSAsync();
        Task<ItemResponse<ProductCategoryModel>> GetItemAsync(string id);
        Task<ItemResponse<ProductCategoryModel>> DeleteItemAsync(string id);
        Task<ItemResponse<ProductCategoryModel>> UpsertItemAsync(ProductCategoryModel category);
    }
}
