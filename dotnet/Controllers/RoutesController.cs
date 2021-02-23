using System.Threading.Tasks;
using DotNetService.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetService.Controllers
{
    // We are removing response cache at the controller level so we can test the app without worrying about cdn/browser cache.
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class RoutesController : Controller
    {
        private readonly IProductService _productService;
        
        public RoutesController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Retrieves a product with search tags.
        /// </summary>
        /// <param name="id">The id of the product.</param>
        /// <returns>A tagged product.</returns>
        [HttpGet]
        public async Task<IActionResult> GetTaggedProduct(int id)
        {
            if (id <= 0) return BadRequest("The required 'id' parameter must be a non-zero positive integer.");
            return Ok(await _productService.GetTaggedProduct(id));
        }
        
        [HttpGet]
        public IActionResult HealthCheck()
        {
            return Ok();
        }
    }
}