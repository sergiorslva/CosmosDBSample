using AzureCosmosDotNet.Models;
using AzureCosmosDotNet.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureCosmosDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderDbService _orderDbService;

        public OrderController(ILogger<OrderController> logger, IOrderDbService orderDbService )
        {
            _logger = logger;
            this._orderDbService = orderDbService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderModel orderModel)
        {
            return Ok(await _orderDbService.CreateOrderAsync(orderModel));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemAsync(string id)
        {
            return Ok(await _orderDbService.GetItemAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetItemsAsync()
        {
            return Ok(await _orderDbService.GetItemsAsync());
        }
    }
}
