using AzureCosmosDotNet.Models;
using Microsoft.Azure.Cosmos;

namespace AzureCosmosDotNet.Services.Interfaces
{
    public interface IOrderDbService
    {
        Task<ItemResponse<OrderModel>> CreateOrderAsync(OrderModel customer);
        Task<IEnumerable<OrderModel>> GetItemsAsync();
        Task<ItemResponse<OrderModel>> GetItemAsync(string id);        
    }
}
