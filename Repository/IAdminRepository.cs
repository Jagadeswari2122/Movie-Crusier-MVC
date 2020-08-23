using movie_crusier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movie_crusier.Repository
{
    interface IAdminRepository
    {
        public List<Movies> GetAllMovies();
        public void AddMovie(Movies movie);
        public void UpdateMovie(Movies movie);
        public Movies GetMovieById(int? id);

        public void DeleteMovie(int id);

    }
}
