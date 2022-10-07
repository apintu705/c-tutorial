using BddAssignment3.movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddAssignment3.Repository
{
    public class MovieRepo
    {
        private readonly List<MovieModel> _movieList ;
        public MovieRepo()
        {
            _movieList = new List<MovieModel>();
        }

        public void SetMovieToList(MovieModel movie)
        {   
            _movieList.Add(movie);
        }
        public  List<MovieModel> GetMovieFromList()
        {
            return _movieList;
        }
    }
}
