using AzureCosmosDotNet.Models;
using AzureCosmosDotNet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AzureCosmosDotNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly ILogger<ProductCategoryController> _logger;
        private readonly IProductCategoryDbService _categoryDbService;

        public ProductCategoryController(ILogger<ProductCategoryController> logger, IProductCategoryDbService categoryDbService)
        {
            _logger = logger;
            this._categoryDbService = categoryDbService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _categoryDbService.GetItemSAsync());
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetItemAsync(string id)
        {
            return Ok(await _categoryDbService.GetItemAsync(id));
        }

        [HttpDelete("id/{id}")]
        public async Task<IActionResult> DeleteItemAsync(string id)
        {
            return Ok(await _categoryDbService.DeleteItemAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpsertItemAsync([FromBody] ProductCategoryModel category)
        {
            return Ok(await _categoryDbService.UpsertItemAsync(category));
        }

    }
}
