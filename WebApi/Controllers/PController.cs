using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PController : ControllerBase
    {
        private static List<Products> _products = new List<Products>();

        public PController()
        {
            /// er tom så der ikke bliver smidt de samme ting ud flere, når man henter GET.
            /// ellers skal den måske laves om til et static objekt
        }

        [HttpGet("count")] ///Tæller hvor mange Products der er
        public int GetCount()
        {
            return _products.Count;
        }

        [HttpGet]
        public IActionResult Get() /// Henter Product list
        {
            if (_products.Count == 0)
            {
                return NoContent();
            }

            return Ok(_products);
        }

        [HttpPost]
        public ActionResult<Products> Post(Products product) /// Gør så vi kan POST et nyt 
        {
            if (string.IsNullOrEmpty(product.Name)) /// Sender en fejl tilbage hvis der ikke er noget navn
            {
                return BadRequest("Product name cannot be empty.");
            }

            if (product.Price <= 0) /// Sender en fejl tilbage hvis prisen ikke er højere end 0
            {
                return BadRequest("Product price must be greater than 0.");
            }

            product.Id = _products.Count + 1;
            _products.Add(product);

            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }
    }
}
