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
    public class CategoriesController : ControllerBase
    {
        private readonly BLLServiceInterface _context;

        public CategoriesController(BLLServiceInterface context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public ActionResult<IEnumerable<CategoryBLLModel>> GetCategorys()
        {
            return _context.GetAllCategorys();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<CategoryBLLModel> GetCategory(int id)
        {
            var category = _context.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, CategoryBLLModel category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            _context.UpdateCategory(category);

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<CategoryBLLModel> PostCategory(CategoryBLLModel category)
        {
            _context.AddCategory(category);

            return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public ActionResult<CategoryBLLModel> DeleteCategory(int id)
        {
            var category = _context.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.DeleteCategory(id);

            return category;
        }
    }
}
