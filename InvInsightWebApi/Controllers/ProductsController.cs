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
        public async Task<ActionResult<IEnumerable<ProductOutputDto>>> GetProducts()
        {
            var products = await _productService.GetAllProductDtosAsync();

            if (products is null || !products.Any())
            {
                return NoContent();
            }

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<ProductOutputDto>> CreateProduct([FromBody] ProductCreateDto productCreateDto)
        {
            try
            {
                var product = await _productService.CreateProductFromDto(productCreateDto);
                var productOuputDto = new ProductOutputDto(product);
                return Created(nameof(CreateProduct), productOuputDto);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ProductOutputDto>> UpdateProduct([FromBody] ProductUpdateDto productUpdateDto)
        {
            try
            {
                var product = await _productService.UpdateProductFromDto(productUpdateDto);
                var productOuputDto = new ProductOutputDto(product);
                return Ok(productOuputDto);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductOutputDto>> DeleteProduct(int id)
        {
            try
            {
                await _productService.DeleteProduct(id);
                return NoContent();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
