using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLinq
{
    public class LinqMethods : LinqInterface
    {
        private readonly List<MovieModel> _movies;
        public LinqMethods()
        {
            _movies = new List<MovieModel>();
        }
        public void AddMovie()
        {
            _movies.Add(new MovieModel(1, "bahubai", 2010, "action"));
            _movies.Add(new MovieModel(2, "dabbang", 2017, "action"));
            _movies.Add(new MovieModel(3, "Avatar", 2019, "fantasy"));
            _movies.Add(new MovieModel(4, "pirates", 2020, "fantasy"));

        }
        public void LinqFunction()
        {
            var m = _movies.Where(m => m.Name == "pirates");
            foreach (var movieItem in m)
            {
                Console.WriteLine($"{movieItem.Id} {movieItem.Name} {movieItem.Year} {movieItem.Gener}");
            }

            var mo = _movies.Select(m => m.Name);
            foreach (var movieItem in mo)
            {
                Console.WriteLine($"{movieItem}");
            }

            var mov = _movies.OrderBy(m => m.Year);
            foreach (var movieItem in mov)
            {
                Console.WriteLine($"{movieItem.Id} {movieItem.Name} {movieItem.Year} {movieItem.Gener}");
            }
            var movi = _movies.GroupBy(m => m.Gener);
            foreach(var movieItem in movi)
            {
                Console.WriteLine(movieItem.Key);
                var movieItems = movieItem.OrderByDescending(m => m.Year);
                foreach(var movie in movieItems)
                {
                    Console.WriteLine($"{movie.Id} {movie.Name} {movie.Year} {movie.Gener}");
                }
            }
        }
    }
}
