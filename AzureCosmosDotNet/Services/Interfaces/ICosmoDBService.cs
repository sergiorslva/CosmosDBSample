using Microsoft.Azure.Cosmos;

namespace AzureCosmosDotNet.Services.Interfaces
{
    public interface ICosmoDBService
    {
        Task<Container> CreateContainerAsync(string container, string partitionKey);        
    }
}
