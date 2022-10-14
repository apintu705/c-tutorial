using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IProducerRepository
    {
        void SetProducerToList(Producer producer);
        int ProducerId();
        List<Producer> GetProducersfromList();
    }
}
