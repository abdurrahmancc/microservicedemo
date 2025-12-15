using Catalog.API.Interfaces.Manager;
using Catalog.API.Models;
using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : BaseController
    {
        private readonly IProductManager _productManager;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(
            IProductManager productManager,
            ILogger<CatalogController> logger)
        {
            _productManager = productManager;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), 200)]
        [ResponseCache(Duration = 30)]
        public IActionResult GetProducts()
        {
            return CustomResult("Data loaded successfully", _productManager.GetAll());
        }

        [HttpGet("category/{category}")]
        public IActionResult GetByCategory(string category)
        {
            return CustomResult("Data loaded successfully", _productManager.GetByCategory(category));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var product = _productManager.GetById(id);
            if (product == null)
                return CustomResult("Not found", HttpStatusCode.NotFound);

            return CustomResult("Data loaded successfully", product);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            product.Id = Guid.NewGuid().ToString();
            _productManager.Add(product);
            return CustomResult("Created", product, HttpStatusCode.Created);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(string id, Product product)
        {
            product.Id = id;
            _productManager.Update(id, product);
            return CustomResult("Updated", product);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(string id)
        {
            _productManager.Delete(id);
            return CustomResult("Deleted");
        }
    }

}
