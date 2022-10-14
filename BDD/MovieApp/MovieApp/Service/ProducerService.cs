using Domain;
using Repository.Interfaces;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Service.Interfaces;

namespace MovieApp.Service
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepository;
        public ProducerService()
        {
            _producerRepository = new ProducerRepository();
        }
        public void AddProducer(string producerName, DateTime dOB)
        {
            if (string.IsNullOrEmpty(producerName))
            {
                throw new ArgumentException("Invalid arguments");
            }

            int id = _producerRepository.ProducerId();
            _producerRepository.SetProducerToList(new Domain.Producer(producerName, dOB, id));
        }

        public List<Producer> GetProducers()
        {
            return _producerRepository.GetProducersfromList();
        }
    }
}
