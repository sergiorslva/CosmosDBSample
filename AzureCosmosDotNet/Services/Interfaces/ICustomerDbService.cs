using AzureCosmosDotNet.Models;
using Microsoft.Azure.Cosmos;

namespace AzureCosmosDotNet.Services.Interfaces
{
    public interface ICustomerDbService
    {        
        Task<IEnumerable<CustomerModel>> GetItemsAsync();
        Task<ItemResponse<CustomerModel>> GetItemAsync(string id);
        Task<ItemResponse<CustomerModel>> DeleteItemAsync(string id);
        Task<ItemResponse<CustomerModel>> UpsertItemAsync(CustomerModel customer);
    }
}
