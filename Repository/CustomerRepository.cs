using movie_crusier.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace movie_crusier.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        string connectionString = "Data Source=DESKTOP-JC6IUA3\\SQLEXPRESS;Initial Catalog=MoviesDB;Persist Security Info=True;User ID=sa;Password=12345";
        public void AddToFavorites(Movies movie)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Favorites(Title, BoxOffice,DateOfLaunch,Genre,Active,HasTeaser,MovieId) VALUES(@Title, @BoxOffice,@DateOfLaunch,@Genre,@Active,@HasTeaser,@MovieId)", con);
                command.Parameters.AddWithValue("@Title", movie.Title);
                command.Parameters.AddWithValue("@BoxOffice", movie.BoxOffice);
                command.Parameters.AddWithValue("@DateOfLaunch", movie.Date);
                command.Parameters.AddWithValue("@Genre", movie.Genre);
                command.Parameters.AddWithValue("@Active", movie.Active);
                command.Parameters.AddWithValue("@HasTeaser", movie.HasTeaser);
                command.Parameters.AddWithValue("@MovieId", movie.MovieId);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }
        public Movies GetMovieById(int? id)
        {

            Movies movie = new Movies();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Movies WHERE MovieId= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    movie.MovieId = Convert.ToInt32(rdr["MovieId"]);
                    movie.Title = rdr["Title"].ToString();
                    movie.BoxOffice = rdr["BoxOffice"].ToString();
                    movie.Date = rdr["DateOfLaunch"].ToString();
                    movie.Genre = rdr["Genre"].ToString();
                    movie.Active = rdr["Active"].ToString();
                    movie.HasTeaser = rdr["HasTeaser"].ToString();
                }
            }
            return movie;

        }
        public void DeleteMovieInFavorites(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Favorites WHERE FavoriteId=@FavoriteId", con);


                cmd.Parameters.AddWithValue("@FavoriteId", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<Favorites> GetMoviesInFavorites()
        {
            List<Favorites> favoritesList = new List<Favorites>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("select * from Favorites", con);
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Favorites favorites = new Favorites();
                    favorites.FavoriteId = Convert.ToInt32(reader["FavoriteId"]);
                    favorites.Title = reader["Title"].ToString();
                    favorites.BoxOffice = reader["BoxOffice"].ToString();
                    favorites.Date = reader["DateOfLaunch"].ToString();
                    favorites.Genre= reader["Genre"].ToString();
                    favorites.Active = reader["Active"].ToString();
                    favorites.MovieId = Convert.ToInt32(reader["MovieId"]);
                    favorites.HasTeaser = reader["HasTeaser"].ToString();

                    favoritesList.Add(favorites);
                }
                con.Close();
            }
            return favoritesList;
        }

        public Favorites GetFavoriteMovieById(int? favoriteId)
        {
            Favorites favorites = new Favorites();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Favorites WHERE FavoriteId= " + favoriteId;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    favorites.FavoriteId = Convert.ToInt32(rdr["FavoriteId"]);
                    favorites.Title = rdr["Title"].ToString();
                    favorites.BoxOffice = rdr["BoxOffice"].ToString();
                    favorites.Date = rdr["DateOfLaunch"].ToString();
                    favorites.Genre = rdr["Genre"].ToString();
                    favorites.Active = rdr["Active"].ToString();
                    favorites.MovieId = Convert.ToInt32(rdr["MovieId"]);
                    favorites.HasTeaser = rdr["HasTeaser"].ToString();
                }
            }
            return favorites;
        }


    }
}
