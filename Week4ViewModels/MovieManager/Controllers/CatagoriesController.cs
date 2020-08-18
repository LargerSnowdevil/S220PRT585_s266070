using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieManager.Data;
using MovieManager.Models;

namespace MovieManager.Controllers
{
    public class CatagoriesController : Controller
    {
        private readonly MovieDBContext _context;

        public CatagoriesController(MovieDBContext context)
        {
            _context = context;
        }

        // GET: Catagories
        public async Task<ActionResult<CatagoryModel>> Index()
        {
            var efModel = _context.Catagorys.ToList();
            var catList = new List<CatagoryModel>();

            foreach (var item in efModel)
            {
                catList.Add(new CatagoryModel()
                {
                    catagoryID = item.catagoryID,
                    name = item.name
                });
            }

            return View(catList);
        }

        // GET: Catagories/Details/5
        public async Task<ActionResult<CatagoryModel>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var efModel = _context.Catagorys.Find(id);
            if (efModel == null)
            {
                return NotFound();
            }

            var catModel = new CatagoryModel()
            {
                catagoryID = efModel.catagoryID,
                name = efModel.name
            };

            return View(catModel);
        }

        // GET: Catagories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catagories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("catagoryID,name")] Catagory catagory)
        {
            if (ModelState.IsValid)
            {
                var efModel = new Catagory()
                {
                    catagoryID = catagory.catagoryID,
                    name = catagory.name
                };
                _context.Catagorys.Add(efModel);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(catagory);
        }

        // GET: Catagories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var efModel = _context.Catagorys.Find(id);
            if (efModel == null)
            {
                return NotFound();
            }

            var catModel = new CatagoryModel()
            {
                catagoryID = efModel.catagoryID,
                name = efModel.name
            };

            return View(catModel);
        }

        // POST: Catagories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("catagoryID,name")] Catagory catagory)
        {
            if (id != catagory.catagoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var efModel = _context.Catagorys.Find(catagory.catagoryID);
                    efModel.name = catagory.name;
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatagoryExists(catagory.catagoryID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catagory);
        }

        // GET: Catagories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var efModel = _context.Catagorys.Find(id);
            if (efModel == null)
            {
                return NotFound();
            }

            var catModel = new CatagoryModel()
            {
                catagoryID = efModel.catagoryID,
                name = efModel.name
            };

            return View(catModel);
        }

        // POST: Catagories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catagory = await _context.Catagorys.FindAsync(id);
            _context.Catagorys.Remove(catagory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatagoryExists(int id)
        {
            return _context.Catagorys.Any(e => e.catagoryID == id);
        }
    }
}
