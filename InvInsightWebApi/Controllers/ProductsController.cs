using InvInsightWebApi.Models;
using InvInsightWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvInsightWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductOutputDto>>> Get()
        {
            var products = await _productService.GetAllProductDtosAsync();

            if (products is null || !products.Any())
            {
                return NoContent();
            }

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<ProductOutputDto>> CreateProduct([FromBody] ProductCreateDto productInputDto)
        {
            try
            {
                var product = await _productService.CreateProductFromDto(productInputDto);
                return Created(nameof(CreateProduct), product);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
