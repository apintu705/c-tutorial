using MovieApp.Domain;
using MovieApp.Repository;
using MovieApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services
{
    public class ProducerService : IProducerService
    {
        public void AddProducer(string producerName, DateTime dOB)
        {
            if (string.IsNullOrEmpty(producerName))
            {
                throw new ArgumentException("Invalid arguments");
            }

            ProducerRepository.SetProducerToList(new Domain.Producer(producerName, dOB));
        }

        public List<Producer> GetProducers()
        {
            return ProducerRepository.GetProducersfromList();
        }
    }
}
