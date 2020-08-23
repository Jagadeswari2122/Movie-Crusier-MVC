using movie_crusier.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace movie_crusier.Repository
{
    public class AdminRepository:IAdminRepository
    {
        string connectionString = "Data Source=DESKTOP-JC6IUA3\\SQLEXPRESS;Initial Catalog=MoviesDB;Persist Security Info=True;User ID=sa;Password=12345";
        public void AddMovie(Movies movie)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Movies(Title, BoxOffice,DateOfLaunch,Genre,Active,HasTeaser) VALUES(@Title, @BoxOffice,@DateOfLaunch,@Genre,@Active,@HasTeaser)", con);
                command.Parameters.AddWithValue("@Title", movie.Title);
                command.Parameters.AddWithValue("@BoxOffice", movie.BoxOffice);
                command.Parameters.AddWithValue("@DateOfLaunch", movie.Date);
                command.Parameters.AddWithValue("@Genre", movie.Genre);
                command.Parameters.AddWithValue("@Active", movie.Active);
                command.Parameters.AddWithValue("@HasTeaser", movie.HasTeaser);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteMovie(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Movies WHERE MovieId=@MovieId", con);


                cmd.Parameters.AddWithValue("@MovieId", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<Movies> GetAllMovies()
        {
            List<Movies> moviesList = new List<Movies>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("select * from Movies", con);
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Movies movie = new Movies();
                    movie.MovieId = Convert.ToInt32(reader["MovieId"]);
                    movie.Title = reader["Title"].ToString();
                    movie.BoxOffice = reader["BoxOffice"].ToString();
                    movie.Date = reader["DateOfLaunch"].ToString();
                    movie.Genre = reader["Genre"].ToString();
                    movie.Active = reader["Active"].ToString();
                    movie.HasTeaser = reader["HasTeaser"].ToString();

                    moviesList.Add(movie);
                }
                con.Close();
            }
            return moviesList;
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

        public void UpdateMovie(Movies movie)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE Movies SET Title=@Title, BoxOffice=@BoxOffice,DateOfLaunch=@DateOfLaunch,Genre=@Genre,Active=@Active,HasTeaser=@HasTeaser Where MovieId=@MovieId", con);
                command.Parameters.AddWithValue("@MovieId", movie.MovieId);
                command.Parameters.AddWithValue("@Title", movie.Title);
                command.Parameters.AddWithValue("@BoxOffice", movie.BoxOffice);
                command.Parameters.AddWithValue("@DateOfLaunch", movie.Date);
                command.Parameters.AddWithValue("@Genre", movie.Genre);
                command.Parameters.AddWithValue("@Active", movie.Active);
                command.Parameters.AddWithValue("@HasTeaser", movie.HasTeaser);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
