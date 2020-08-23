using movie_crusier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movie_crusier.Repository
{
    interface ICustomerRepository
    {
        public void AddToFavorites(Movies movie);
        public List<Favorites> GetMoviesInFavorites();
        public void DeleteMovieInFavorites(int id);
        public Favorites GetFavoriteMovieById(int? favoriteId);
    }
}
