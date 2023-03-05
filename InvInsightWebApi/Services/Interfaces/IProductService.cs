using InvInsightWebApi.Models;

namespace InvInsightWebApi.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductOutputDto>> GetAllProductDtosAsync();
    }
}
