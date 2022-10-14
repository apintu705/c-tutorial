using Domain;
using Repository.Interfaces;

namespace Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly List<Movie> _movies;
        public MovieRepository()
        {
            _movies = new List<Movie>();
        }

        public void SetMovieToList(Movie movie)
        {
            _movies.Add(movie);
        }

        public int MovieId()
        {
            if(_movies.Count == 0)
            {
                return 1;
            }
            else
            {
                return _movies[_movies.Count - 1].Id + 1;
            }
        }
        public List<Movie> GetMoviesFromList()
        {
            return _movies.ToList();
        }
        public void DeleteMovieFromList(int index)
        {
            var itemToRemove = _movies.Single(r => r.Id == index);
            _movies.Remove(itemToRemove);
        }
    }
}