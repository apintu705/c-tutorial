using BddAssignment3.movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddAssignment3.Repository.Interface
{
    public  interface IMovieRepo
    {
        void SetMovieToList(MovieModel movie);
        List<MovieModel> GetMovieFromList();
    }
}
