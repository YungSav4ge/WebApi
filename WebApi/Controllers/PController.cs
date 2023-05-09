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
            return Ok(_products);
        }

        [HttpPost]
        public ActionResult<Products> Post(Products product) /// Gør så vi kan POST et nyt 
        {
            product.Id = _products.Count + 1;
            _products.Add(product);

            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }
    }
}
