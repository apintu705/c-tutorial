using MovieApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Repository
{
    public class ProducerRepository
    {
        private readonly static List<Producer> _producers = new List<Producer>();

        public static void SetProducerToList(Producer producer)
        {
            _producers.Add(producer);
        }

        public static List<Producer> GetProducersfromList()
        {
            return _producers.ToList();
        }
    }
}
