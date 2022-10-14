using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IMovieRepository
    {
        void SetMovieToList(Movie movie);
        int MovieId();
        List<Movie> GetMoviesFromList();
        void DeleteMovieFromList(int index);
    }
}
