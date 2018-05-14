﻿using MovieMix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.GenreN).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }

    }
}