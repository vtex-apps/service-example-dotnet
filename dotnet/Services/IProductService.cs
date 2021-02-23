using System.Threading.Tasks;
using DotNetService.Models;

namespace DotNetService.Services
{
    public interface IProductService
    {
        Task<TaggedProduct> GetTaggedProduct(int productId);
    }
}