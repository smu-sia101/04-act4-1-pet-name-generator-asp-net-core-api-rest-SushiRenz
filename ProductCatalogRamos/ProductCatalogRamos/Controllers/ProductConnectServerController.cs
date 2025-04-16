using Microsoft.AspNetCore.Mvc;
using ProductCatalogServiceRamos.ProductModels;
using ProductCatalogServiceRamos.Services;

namespace ProductCatalogServiceRamos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductConnectServerController : Controller
    {
        private readonly ProductsService _productsServices;

        public ProductConnectServerController(ProductsService ProductsServices)
        {
            _productsServices = ProductsServices;
        }

        [HttpGet]
        public async Task<List<Products>> Get() =>
        await _productsServices.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Products>> Get(string id)
        {
            var product = await _productsServices.GetAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Products newProducts)
        {
            await _productsServices.CreateAsync(newProducts);

            return CreatedAtAction(nameof(Get), new { id = newProducts.Id }, newProducts);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Products updatedProducts)
        {
            var product = await _productsServices.GetAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            updatedProducts.Id = product.Id;

            await _productsServices.UpdateAsync(id, updatedProducts);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _productsServices.GetAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            await _productsServices.RemoveAsync(id);

            return NoContent();
        }

    }
}
