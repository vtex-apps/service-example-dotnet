using System.Threading.Tasks;
using DotNetService.Models;
using Refit;

namespace DotNetService.Data
{
    public interface IProductRepository
    {
        // We are using refit so the request method, relative url, custom headers and parameters are set through these attributes
        [Headers("Cache-Control: no-cache")]
        [Get("/api/catalog/pvt/product/{productId}")]
        Task<Product> GetProduct(int productId);
    }
}