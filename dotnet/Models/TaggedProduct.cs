using System;
using System.Linq;

namespace DotNetService.Models
{
    public class TaggedProduct
    {
        public int Id { get; }
        public string Name { get;}
        
        // This is an oversimplified way to automatically create search tags for the sake of providing an interesting example.
        public string[] Tags => Name?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Where(s => s.Length > 3)
            .Select(s=> s.ToLowerInvariant())
            .ToArray() ?? new string[0];

        public TaggedProduct(Product product) => (Id, Name) = (product.Id, product.Name);
    }
}