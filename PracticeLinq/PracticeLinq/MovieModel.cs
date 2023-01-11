using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLinq
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Gener { get; set; }
        public MovieModel(int id, string name, int year, string gener)
        {
            Id = id;
            Name = name;
            Year = year;
            Gener = gener;
        }
    }
}
