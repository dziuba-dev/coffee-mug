using CoffeeMug.Infrastructure.Commands;
using CoffeeMug.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CoffeeMug.API.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductServic _productServic;

        public ProductController(IProductServic productServic)
        {
            _productServic = productServic;
        }

        [HttpGet ("get")]
        public async Task<IActionResult> Get()
        {
            var result = await _productServic.GetAsync();

            return Json(result);
        }

        [HttpGet ("get/{productId}")]
        public async Task<IActionResult> Get(Guid productId)
        {
            var result = await _productServic.GetAsync(productId);

            return Json(result);
        }

        [HttpPost ("createProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProduct command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productId = Guid.NewGuid();
            await _productServic.CreateAsync(productId, command.Name, command.Price);

            return StatusCode(201);
        }

        [HttpPut ("updateProduct/{productId}")]
        public async Task<IActionResult> UpdateProducr(Guid productId, [FromBody] UpdateProduct command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productServic.UpdateAsync(productId, command.Name, command.Price);

            return NoContent();
        }

        [HttpDelete ("deleteProduct/{productId}")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            await _productServic.DeleteAsync(productId);

            return NoContent();
        }
    }
}
