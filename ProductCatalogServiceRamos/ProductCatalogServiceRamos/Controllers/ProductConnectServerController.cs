using Microsoft.AspNetCore.Mvc;

namespace ProductCatalogServiceRamos.Controllers
{
    [ApiController]
    [Route("[Controller")]
    public class ProductConnectServerController : Controller
    {
        [HttpGet("/api/products")]
        public IActionResult GetAllProducts()
        {
            return Ok();
        }

        [HttpGet("/api/products/{id}")]
        public IActionResult GetProductById(int id)
        {
            return Ok();
        }

        [HttpPost("/api/products")]
        public IActionResult AddProduct()
        {
            return Ok();
        }

        [HttpPut("/api/products/{id}")]
        public IActionResult UpdateProduct(int id)
        {
            return Ok();
        }

        [HttpDelete("/api/products/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            return Ok();
        }
    }

}
