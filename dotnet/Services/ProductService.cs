using System.Threading.Tasks;
using DotNetService.Data;
using DotNetService.Models;

namespace DotNetService.Services
{
    // This is the service that delegates the product retrieval and tagging.
    // The business logic is inside the model layer.
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        /// <summary>
        /// Retrieves and creates search tags for a product.
        /// </summary>
        /// <param name="productId">The id of the product.</param>
        /// <returns>A product with search tags.</returns>
        public async Task<TaggedProduct> GetTaggedProduct(int productId)
        {
            var product = await _productRepository.GetProduct(productId);
            return product == null ? null : new TaggedProduct(product);
        }
    }
}