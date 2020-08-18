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
    public class MoviesController : Controller
    {
        private readonly MovieDBContext _context;

        public MoviesController(MovieDBContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var efModel = _context.Movies.ToList();
            var movieList = new List<MovieModel>();

            foreach (var item in efModel)
            {
                movieList.Add(new MovieModel()
                {
                    movieID = item.movieID,
                    movieName = item.movieName,
                    releaseDate = item.releaseDate,
                    directorName = item.directorName,
                    contactAdress = item.contactAdress,
                    movieLanguage = item.movieLanguage,
                    catagory = _context.Catagorys.Find(item.catagoryID).name
                });
            }

            return View(movieList);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var efModel = _context.Movies.Find(id);
            if (efModel == null)
            {
                return NotFound();
            }

            var movieModel = new MovieModel()
            {
                movieID = efModel.movieID,
                movieName = efModel.movieName,
                releaseDate = efModel.releaseDate,
                directorName = efModel.directorName,
                contactAdress = efModel.contactAdress,
                movieLanguage = efModel.movieLanguage,
                catagory = _context.Catagorys.Find(efModel.catagoryID).name
            };

            return View(movieModel);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewData["catagoryID"] = new SelectList(_context.Catagorys, "catagoryID", "name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("movieID,movieName,releaseDate,directorName,contactAdress,movieLanguage,catagoryID")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                var efModel = new Movie()
                {
                    movieID = movie.movieID,
                    movieName = movie.movieName,
                    releaseDate = movie.releaseDate,
                    directorName = movie.directorName,
                    contactAdress = movie.contactAdress,
                    movieLanguage = movie.movieLanguage,
                    catagoryID = movie.catagoryID
                };
                _context.Movies.Add(efModel);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var efModel = _context.Movies.Find(id);
            if (efModel == null)
            {
                return NotFound();
            }

            var movieModel = new MovieModel()
            {
                movieID = efModel.movieID,
                movieName = efModel.movieName,
                releaseDate = efModel.releaseDate,
                directorName = efModel.directorName,
                contactAdress = efModel.contactAdress,
                movieLanguage = efModel.movieLanguage,
                catagory = _context.Catagorys.Find(efModel.catagoryID).name
            };

            ViewData["catagoryID"] = new SelectList(_context.Catagorys, "catagoryID", "name");
            return View(movieModel);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("movieID,movieName,releaseDate,directorName,contactAdress,movieLanguage,catagoryID")] Movie movie)
        {
            if (id != movie.movieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var efModel = _context.Movies.Find(movie.movieID);
                    efModel.movieID = movie.movieID;
                    efModel.movieName = movie.movieName;
                    efModel.releaseDate = movie.releaseDate;
                    efModel.directorName = movie.directorName;
                    efModel.contactAdress = movie.contactAdress;
                    efModel.movieLanguage = movie.movieLanguage;
                    efModel.catagoryID = movie.catagoryID;
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.movieID))
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
            ViewData["catagoryID"] = new SelectList(_context.Catagorys, "catagoryID", "name", movie.catagoryID);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var efModel = _context.Movies.Find(id);
            if (efModel == null)
            {
                return NotFound();
            }

            var movieModel = new MovieModel()
            {
                movieID = efModel.movieID,
                movieName = efModel.movieName,
                releaseDate = efModel.releaseDate,
                directorName = efModel.directorName,
                contactAdress = efModel.contactAdress,
                movieLanguage = efModel.movieLanguage,
                catagory = _context.Catagorys.Find(efModel.catagoryID).name
            };

            ViewData["catagoryID"] = new SelectList(_context.Catagorys, "catagoryID", "name");
            return View(movieModel);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.movieID == id);
        }
    }
}
