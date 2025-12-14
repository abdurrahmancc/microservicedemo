
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
    }

}
