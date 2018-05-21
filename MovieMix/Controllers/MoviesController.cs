using MovieMix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MovieMix.Migrations;
using MovieMix.ViewModels;
namespace MovieMix.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
               //New Constructor
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        // GET: Movies
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.GenreN).ToList();
            return View(movies);
        }
        public ViewResult New()
        {
            var genres = _context.GenresN.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if(movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.GenresN.ToList()

            };
            return View("MovieForm", viewModel);

        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0){
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.Genre = movie.Genre;
                movieInDb.NumberofStocks = movie.NumberofStocks;
                movieInDb.ReleaseDate = movie.ReleaseDate;
               // movieInDb.DateAdded = movie.DateAdded;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Details(int? id)
        {
            var movie = _context.Movies.Include(m => m.GenreN).SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);

        }

    }
}