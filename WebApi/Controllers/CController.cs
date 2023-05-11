using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CController : ControllerBase
    {

        private static List<Catalog> _catalogs = new List<Catalog>();

        [HttpGet]
        public ActionResult<IEnumerable<Catalog>> GetCatalogs()
        {
            if (_catalogs.Count == 0)
            {
                return NoContent();
            }

            return _catalogs;
        }

        [HttpPost]
        public ActionResult PostCatalog([FromBody] Catalog catalog)
        {
            if (string.IsNullOrEmpty(catalog.Name)) /// Sender en fejl tilbage hvis der ikke er noget navn
            {
                return BadRequest("Catalog name cannot be empty.");
            }

            catalog.Id = _catalogs.Count + 1;
            _catalogs.Add(catalog);

            return CreatedAtAction(nameof(GetCatalogs), new { id = catalog.Id }, catalog);
        }
    }
}
