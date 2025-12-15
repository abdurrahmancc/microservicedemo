
using Catalog.API.Context;
using Catalog.API.Interfaces.Manager;
using Catalog.API.Interfaces.Repository;
using Catalog.API.Models;
using Catalog.API.Repository;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Manager
{
    public class ProductManager : IProductManager
    {
        private readonly CatalogDbContext  _context;

        public ProductManager(CatalogDbContext context)
        {
            _context = context;
        }

        public List<Product> GetByCategory(string category)
        {
            return _context.Products
                .AsNoTracking()                    
                .Where(p => p.Category == category) 
                .ToList();
        }

        public List<Product> GetAll()
        {
            return _context.Products
                .AsNoTracking()
                .ToList();
        }

        public Product? GetById(string id)
        {
            return _context.Products
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == id);
        }


        public bool Add(Product product)
        {
            _context.Products.Add(product);
            return _context.SaveChanges() > 0;
        }

        public bool Update(string id, Product product)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
                return false;

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Category = product.Category;
            existingProduct.Summary = product.Summary;
            existingProduct.ImageFile = product.ImageFile;

            _context.Products.Update(existingProduct);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(string id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return false;

            _context.Products.Remove(product);
            return _context.SaveChanges() > 0;
        }
    }
}


