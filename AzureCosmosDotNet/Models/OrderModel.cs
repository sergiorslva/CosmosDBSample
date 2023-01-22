using Newtonsoft.Json;

namespace AzureCosmosDotNet.Models
{
    public class OrderModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; }

        [JsonProperty("type")]
        public string Type { get; private set; } = "order";

        [JsonProperty("details")]
        public IEnumerable<OrderDetailsModel> Details { get; set; } = new List<OrderDetailsModel>();
    }

    public class OrderDetailsModel
    {
        [JsonProperty("productId")]
        public string ProductId { get; set; }

        [JsonProperty("productName")]
        public string ProductName { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("quantity")]
        public double Quantity { get; set; }
    }
}
