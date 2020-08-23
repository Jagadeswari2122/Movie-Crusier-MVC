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
    public class CustomerController : Controller
    {
        CustomerRepository customer = new CustomerRepository();
        AdminRepository admin = new AdminRepository();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetMovies()
        {
            List<Movies> lstItems = new List<Movies>();
            lstItems = admin.GetAllMovies().ToList();

            return View(lstItems);
        }
        [HttpGet]
        public IActionResult GetMovie(int? id)
        {
            Movies movie = admin.GetMovieById(id);
            return View(movie);
        }
        [HttpGet]
        public IActionResult AddToFavorites(int? id)
        {
            Movies movie = customer.GetMovieById(id);
            customer.AddToFavorites(movie);
            return View(movie);
        }
        [HttpGet]
        public IActionResult GetFavoriteMovies()
        {
            List<Favorites> favoritesList = new List<Favorites>();
            favoritesList = customer.GetMoviesInFavorites().ToList();

            return View(favoritesList);
        }
        [HttpGet]
        public IActionResult DeleteFavoriteMovie(int? id)
        {
            Favorites favorites = customer.GetFavoriteMovieById(id);

            return View(favorites);
        }

        [HttpPost, ActionName("DeleteFavoriteMovie")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFavoriteMovie(int id)
        {
            customer.DeleteMovieInFavorites(id);
            return RedirectToAction("GetFavoriteMovies");
        }

    }
}