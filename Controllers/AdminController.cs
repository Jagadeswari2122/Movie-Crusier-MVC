using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using movie_crusier.Models;
using movie_crusier.Repository;

namespace movie_crusier.Controllers
{
    public class AdminController : Controller
    {

        AdminRepository admin = new AdminRepository();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddNewMovie()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNewMovie(Movies movie)
        {
            if (ModelState.IsValid)
            {
                admin.AddMovie(movie);
                return RedirectToAction("GetAllMovies");
            }
            return View(movie);
        }
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            List<Movies> moviesList = new List<Movies>();
            moviesList = admin.GetAllMovies().ToList();

            return View(moviesList);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            Movies movie = admin.GetMovieById(id);
            return View(movie);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Movies movie)
        {
            if (ModelState.IsValid)
            {
                admin.UpdateMovie(movie);
                return RedirectToAction("GetAllMovies");
            }
            return View(movie);
        }

        [HttpGet]
        public IActionResult GetMovie(int id)
        {
            Movies movie = admin.GetMovieById(id);
            return View(movie);
        }

        [HttpGet]
        public IActionResult DeleteMovie(int? id)
        {
            Movies movie = admin.GetMovieById(id);

            return View(movie);
        }

        [HttpPost, ActionName("DeleteMovie")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMovie(int id)
        {
            admin.DeleteMovie(id);
            return RedirectToAction("GetAllMovies");
        }

    }
}