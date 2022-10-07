using MovieApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Repository
{
    public class MovieRepository
    {
        private readonly static List<Movie> _movies = new List<Movie>();

        public static void SetMovieToList(Movie movie)
        {
            _movies.Add(movie);
        }

        public static List<Movie> GetMoviesFromList()
        {
            return _movies.ToList();
        }
        public static void DeleteMovieFromList(int index)
        {
            _movies.RemoveAt(index);
        }
    }
}
