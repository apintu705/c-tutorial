using BddAssignment3.movie.Enums;
using BddAssignment3.movie.Interfaces;
using BddAssignment3.Repository;
using BddAssignment3.Repository.Interface;
using BddAssignment3.Service.Interfaces;
using BddAssignment3.Servie;
using BddAssignment3.UserInterface;
using BddAssignment3.utility;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BddAssignment3.movie
{
    public class IMBDServices : IImbdServices
    {
        private readonly IMovieService _movieService;
        public IMBDServices(MovieService movieService)
        {
            _movieService = movieService;
        }
        public void GetMovieReleasedafter()
        {
            var movieList = _movieService.GetMovieList();
            var newMovieList = new List<MovieModel>();

            for (int i = 0; i < movieList.Count; i++)
            {
                string year = DateTime.Parse(movieList[i].ReleaseDate.ToString()).Year.ToString();
                if (Convert.ToInt32(year) >= 2010)
                {
                    newMovieList.Add(movieList[i]);
                }
            }
            if (newMovieList.Count <= 0)
            {
                Utility.PrintMessage("Threre is no movie reseased after 2010", true);
                Thread.Sleep(1000);
                return;
            }

            var table = new ConsoleTable("Movie Name", "Year of release", "plot", "Actors", "Producer");
            foreach (var movie in newMovieList)
            {
                table.AddRow(movie.MovieName, String.Format("{0:M/d/yyyy}", movie.ReleaseDate), movie.MoviePlot, movie.Actors, movie.Producer);
            }
            table.Options.EnableCount = false;
            table.Write();
        }
        public void GetNameOfallMovie()
        {
            var movieList = _movieService.GetMovieList();
            if (movieList.Count <= 0)
            {
                Utility.PrintMessage("There is no movie in the list to show", true);
                Thread.Sleep(1000);
                return;
            }
            else
            {
                var table = new ConsoleTable("Movie Name");

                foreach (var movie in movieList)
                {
                    table.AddRow(movie.MovieName);
                }
                table.Options.EnableCount = false;
                table.Write();
            }
            
        }
        public void GetNameAndReleasedYearOfAllMovies()
        {
            var movieList = _movieService.GetMovieList();
            if (movieList.Count <= 0)
            {
                Utility.PrintMessage("There is no movie in the list to show", true);
                Thread.Sleep(1000);
                return;
            }

            var table = new ConsoleTable("Movie Name", "Year of release");
            foreach (var movie in movieList)
            {
                table.AddRow(movie.MovieName, DateTime.Parse(movie.ReleaseDate.ToString()).Year.ToString());
            }
            table.Options.EnableCount = false;
            table.Write();
        }
        public void GetMovieByNameAvatar()
        {
            var movieList = _movieService.GetMovieList();
            var newList = movieList.Where(e => e.MovieName == "Avatar").LastOrDefault();

            if (newList == null)
            {
                Utility.PrintMessage("There is no movie with name Avatar", true);
                Thread.Sleep(1000);
                return;
            }
            var table = new ConsoleTable("Movie Name", "Year of release", "plot", "Actors", "Producer");
            table.AddRow(newList.MovieName, String.Format("{0:M/d/yyyy}", newList.ReleaseDate), newList.MoviePlot, newList.Actors, newList.Producer);
            table.Options.EnableCount = false;
            table.Write();
        }
        public void GetAllTheMovieWillSmithActed()
        {
            var movieList = _movieService.GetMovieList();
            var newList = movieList.Where(e => e.Actors.Contains("Will Smith")).ToList();

            if (newList.Count <= 0)
            {
                Utility.PrintMessage("There is no movie in which Will Smith acted", false);
                Thread.Sleep(1000);
                return;
            }

            var table = new ConsoleTable("Movie Name", "Year of release", "plot", "Actors", "Producer");
            foreach (var movie in newList)
            {
                table.AddRow(movie.MovieName, String.Format("{0:M/d/yyyy}", movie.ReleaseDate), movie.MoviePlot, movie.Actors, movie.Producer);
            }
            table.Options.EnableCount = false;
            table.Write();
        }
    }

}
