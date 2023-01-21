using Newtonsoft.Json;

namespace AzureCosmosDotNet.Models
{
    public class ProductCategoryModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; private set; } = "category";
    }
}
