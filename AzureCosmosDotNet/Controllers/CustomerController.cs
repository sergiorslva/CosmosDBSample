using AzureCosmosDotNet.Models;
using AzureCosmosDotNet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AzureCosmosDotNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {        
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerDbService _customerDbService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerDbService customerDbService)
        {
            _logger = logger;
            this._customerDbService = customerDbService;
        }        

        [HttpGet]
        public async Task<IActionResult> Get()
        {            
            return Ok(await _customerDbService.GetItemsAsync());
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetItemAsync(string id)
        {           
            return Ok(await _customerDbService.GetItemAsync(id));
        }

        [HttpDelete("id/{id}")]
        public async Task<IActionResult> DeleteItemAsync(string id)
        {
            return Ok(await _customerDbService.DeleteItemAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpsertItemAsync([FromBody] CustomerModel customer)
        {
            return Ok(await _customerDbService.UpsertItemAsync(customer));
        }

    }
}