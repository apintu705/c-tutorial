using Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly List<Producer> _producers;
        public ProducerRepository()
        {
            _producers = new List<Producer>();
        }

        public void SetProducerToList(Producer producer)
        {
            _producers.Add(producer);
        }

        public int ProducerId()
        {
            if(_producers.Count == 0)
            {
                return 1;
            }
            else
            {
                return _producers[_producers.Count - 1].Id + 1;
            }
        }
        public List<Producer> GetProducersfromList()
        {
            return _producers.ToList();
        }
    }
}
