using Newtonsoft.Json;

namespace AzureCosmosDotNet.Models
{
    public class CustomerModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId => this.Id;

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("address")]
        public CustomerAddress Address { get; set; }

        [JsonProperty("orderCount")]
        public int OrderCount { get; private set; }

        [JsonProperty("type")]
        public string Type { get; private set; } = "customer";
    }

    public class CustomerAddress
    {
        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("zipcode")]
        public string ZipCode { get; set; }
    }    
}
