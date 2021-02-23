using System.Collections.Generic;
using System.Linq;
using DotNetService.Models;
using NUnit.Framework;

namespace DotNetService.Tests.Models
{
    [TestFixture]
    public class TaggedProductTests
    {
        // This method provides test cases for the tagging scenarios.
        public static IEnumerable<TestCaseData> TaggedProductProvider()
        {
            yield return new TestCaseData(1, "Super Fast 32GB Memory Computer",
                new[] {"super", "fast", "32gb", "memory", "computer"});
            yield return new TestCaseData(2, "Standard US-Layout Keyboard",
                new[] {"standard", "us-layout", "keyboard"});
            yield return new TestCaseData(3, "Double  Spaces Product",
                new[] {"double", "spaces", "product"});
            yield return new TestCaseData(4, "Product Has Word With Three Characters",
                new[] {"product", "word", "with", "three", "characters"});
        }

        // Same as above with some failing conditions.
        public static IEnumerable<TestCaseData> InvalidTaggedProductProvider()
        {
            yield return new TestCaseData(1, null);
            yield return new TestCaseData(2, "");
            yield return new TestCaseData(2, "   ");
        }

        // We set the TestCaseSource as the name of method which provides data for testing.
        [Test, TestCaseSource(nameof(TaggedProductProvider))]
        public void Tags_ShouldGenerateTags_WhenNameIsValid(int id, string name, string[] expectedTags)
        {
            // Set up
            var taggedProduct = new TaggedProduct(new Product
            {
                Id = id,
                Name = name
            });
            
            // Assert
            Assert.IsTrue(taggedProduct.Tags.SequenceEqual(expectedTags),
                $"Generated Tags: {string.Join(", ", taggedProduct.Tags)} | Expected: {string.Join(", ", expectedTags)} ");
        }

        [Test, TestCaseSource(nameof(InvalidTaggedProductProvider))]
        public void Tags_ShouldGenerateEmptyTags_WhenNameIsInvalid(int id, string name)
        {
            var taggedProduct = new TaggedProduct(new Product
            {
                Id = 1,
                Name = null
            });

            Assert.IsEmpty(taggedProduct.Tags);
        }

        [Test]
        public void Constructor_ShouldCreateTaggedProduct_WhenProductProvided()
        {
            var product = new Product
            {
                Id = 1,
                Name = "My Product"
            };

            var taggedProduct = new TaggedProduct(product);
            Assert.AreEqual(product.Id, taggedProduct.Id);
            Assert.AreEqual(product.Name, taggedProduct.Name);
        }
    }
}