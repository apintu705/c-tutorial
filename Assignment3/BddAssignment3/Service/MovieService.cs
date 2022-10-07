using BddAssignment3.movie;
using BddAssignment3.movie.Interfaces;
using BddAssignment3.Repository;
using BddAssignment3.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddAssignment3.Servie
{
    public class MovieService : IAddMovie
    {
        private readonly MovieRepo _movieRepo;
        public MovieService()
        {
            _movieRepo = new MovieRepo();
        }

        public string AddMovie(string movieName, string moviePlot, DateTime releaseDate, string actor, string producer)
        {
            int id = Utility.GetMovieId();
            if (string.IsNullOrEmpty(movieName)
                || string.IsNullOrEmpty(moviePlot)
                || string.IsNullOrEmpty(actor)
                || string.IsNullOrEmpty(producer))
            {
                return "input filed is empty";
            }
            _movieRepo.SetMovieToList(new MovieModel(id, movieName, moviePlot, releaseDate, actor, producer));
            return "successfully added";
        }

        public List<MovieModel> GetMovieList()
        {
            return _movieRepo.GetMovieFromList();
        }
    }
}
