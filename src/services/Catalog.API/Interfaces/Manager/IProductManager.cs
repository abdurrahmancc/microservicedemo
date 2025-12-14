using Catalog.API.Models;

namespace Catalog.API.Interfaces.Manager
{
    public interface IProductManager
    {
        public List<Product> GetByCategory(string category);
    }
}
