using System.Threading.Tasks;
using DotNetService.Data;
using DotNetService.Models;
using DotNetService.Services;
using Moq;
using NUnit.Framework;

namespace DotNetService.Tests.Services
{
    [TestFixture]
    public class ProductServiceTests
    {
        [Test]
        public async Task GetTaggedProduct_ShouldReturnNull_WhenRepositoryReturnsNull()
        {
            // Setup
            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.GetProduct(It.IsAny<int>()))
                .ReturnsAsync((Product) null);
            
            // Act
            var productService = new ProductService(productRepository.Object);
            var result = await productService.GetTaggedProduct(1);
            
            // Assert
            Assert.IsNull(result);
        }
        
        [Test]
        public async Task GetTaggedProduct_ShouldReturnTaggedProduct_WhenRepositoryReturnsProduct()
        {
            // Setup
            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.GetProduct(It.IsAny<int>()))
                .ReturnsAsync(new Product
                {
                    Id = 1,
                    Name = "My Product"
                });
            
            // Act
            var productService = new ProductService(productRepository.Object);
            var result = await productService.GetTaggedProduct(1);
            
            // Assert
            Assert.IsNotNull(result);
        }
    }
}