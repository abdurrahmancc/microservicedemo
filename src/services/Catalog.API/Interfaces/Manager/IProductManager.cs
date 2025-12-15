using Catalog.API.Models;

namespace Catalog.API.Interfaces.Manager
{
    public interface IProductManager
    {
        public List<Product> GetByCategory(string category);
        List<Product> GetAll();
        Product? GetById(string id);

        bool Add(Product product);
        bool Update(string id, Product product);
        bool Delete(string id);
    }
}
