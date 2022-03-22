using ImportTool.DataAccess.Entities;
using ImportTool.DataAccess.Repositories.Interfaces;
using System;
using System.Linq;

namespace ImportTool.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void Save(Product product)
        {
            Console.WriteLine($"importing: Name: \"{product.Name}\"; Categories: {string.Join(", ", product.Tags.Select(t => t.Name))}; Twitter: {product.Twitter.Name}");
        }
    }
}
