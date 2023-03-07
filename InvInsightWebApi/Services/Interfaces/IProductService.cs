using InvInsightWebApi.Models;

namespace InvInsightWebApi.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductOutputDto>> GetAllProductDtosAsync();
        Task<Product> CreateProductFromDto(ProductCreateDto productInputDto);
        Task<Product> UpdateProductFromDto(ProductUpdateDto productUpdateDto);
        Task DeleteProduct(int id);
        Task<ProductOutputDto> GetProductDtoAsync(int id);
    }
}
