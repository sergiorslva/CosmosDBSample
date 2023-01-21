using Newtonsoft.Json;

namespace AzureCosmosDotNet.Models
{
    public class ProductModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("categoryId")]
        public string CategoryId { get; set; }

    }
}
