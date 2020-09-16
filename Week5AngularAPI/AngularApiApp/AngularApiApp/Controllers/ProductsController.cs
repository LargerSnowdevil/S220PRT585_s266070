using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularApiApp._DAL.Models;
using AngularApiApp._DAL.Services;
using AngularApiApp._BLL.Services;
using AngularApiApp._BLL.Models;

namespace AngularApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly BLLServiceInterface _context;

        public ProductsController(BLLServiceInterface context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<ProductBLLModel>> GetProducts()
        {
            return _context.GetAllProducts();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public ActionResult<ProductBLLModel> GetProduct(int id)
        {
            var product = _context.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, ProductBLLModel product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.UpdateProduct(product);

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<ProductBLLModel> PostProduct(ProductBLLModel product)
        {
            _context.AddProduct(product);

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public ActionResult<ProductBLLModel> DeleteProduct(int id)
        {
            var product = _context.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.DeleteProduct(id);

            return product;
        }
    }
}
