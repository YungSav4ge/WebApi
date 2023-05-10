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

        // GET api/catalogs
        [HttpGet]
        public ActionResult<IEnumerable<Catalog>> GetCatalogs()
        {
            return _catalogs;
        }

        // POST api/catalogs
        [HttpPost]
        public ActionResult PostCatalog([FromBody] Catalog catalog)
        {
            catalog.Id = _catalogs.Count + 1;
            _catalogs.Add(catalog);
            return CreatedAtAction(nameof(GetCatalogs), new { id = catalog.Id }, catalog);
        }
    }
}
