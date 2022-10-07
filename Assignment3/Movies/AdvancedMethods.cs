using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Movies
{
    public class AdvancedMethods
    {
        
        public static void GetMovieReleasedafter(List<Movies> _movieList)
        {
            var newMovieList = new List<Movies>();

            for(int i=0; i<_movieList.Count; i++)
            {
                string year =DateTime.Parse(_movieList[i].YearOfRelease.ToString()).Year.ToString();
                if (Convert.ToInt32(year) >= 2010)
                {
                   newMovieList.Add(_movieList[i]);
                }
            }
            if(newMovieList.Count <= 0)
            {
                Utility.PrintMessage("Threre is no movie reseased after 2010",true);
                return;
            }

            var table = new ConsoleTable("Movie Name", "Year of release", "plot", "Actors", "Producer");
            foreach (var movie in newMovieList)
            {
                table.AddRow(movie.MovieName, String.Format("{0:M/d/yyyy}", movie.YearOfRelease), movie.Plot, movie.Actors, movie.Producer);
            }
            table.Options.EnableCount = false;
            table.Write();
            Utility.PressEnterToContinue();
            
        }
        public static void GetNameOfallMovie(List<Movies> _moviesList)
        {
            if(_moviesList.Count <= 0)
            {
                Utility.PrintMessage("There is no movie in the list to show",true);
                return ;
            }
            var table = new ConsoleTable("Movie Name");

            foreach (var movie in _moviesList)
            {
                table.AddRow(movie.MovieName);
            }

            table.Options.EnableCount = false;
            table.Write();
            Utility.PressEnterToContinue();
        }
        public static void GetNameAndReleasedYearOfAllMovies(List<Movies> _movieList)
        {
            if( _movieList.Count <= 0)
            {
                Utility.PrintMessage("There is no movie in the list to show", true);
                return ;
            }

            var table = new ConsoleTable("Movie Name", "Year of release");
            foreach (var movie in _movieList)
            {
                table.AddRow(movie.MovieName, String.Format("{0:M/d/yyyy}", movie.YearOfRelease));
            }

            table.Options.EnableCount = false;
            table.Write();
            Utility.PressEnterToContinue();
        }
        public static void GetMovieByNameAvatar(List<Movies> _movieList)
        {
            var newList = _movieList.Where(e => e.MovieName == "Avatar").LastOrDefault();
            
            if(newList == null)
            {
                Utility.PrintMessage("There is no movie with name Avatar", true);
                return;
            }
            var table = new ConsoleTable("Movie Name", "Year of release", "plot", "Actors", "Producer");
            
            table.AddRow(newList.MovieName, String.Format("{0:M/d/yyyy}", newList.YearOfRelease), newList.Plot, newList.Actors, newList.Producer);
            
            table.Options.EnableCount = false;
            table.Write();
            Utility.PressEnterToContinue();
            
        }
        public static void GetAllTheMovieWillSmithActed(List<Movies> _movieList)
        {
            var newList = _movieList.Where(e => e.Actors.Contains("Will Smith")).ToList();

            if(newList.Count <= 0)
            {
                Utility.PrintMessage("There is no movie in which Will Smith acted",false);
                return;
            }

            var table = new ConsoleTable("Movie Name", "Year of release", "plot", "Actors", "Producer");
            foreach (var movie in newList)
            {
                table.AddRow(movie.MovieName, String.Format("{0:M/d/yyyy}", movie.YearOfRelease), movie.Plot, movie.Actors, movie.Producer);
            }
            table.Options.EnableCount = false;
            table.Write();
            Utility.PressEnterToContinue();
        }
    }
}
