using Microsoft.Azure.Cosmos;

namespace AzureCosmosDotNet.Services.Interfaces
{
    public interface ICosmoDBService
    {
        Task<ContainerResponse> CreateContainerAsync(string container, string partitionKey);        
    }
}
