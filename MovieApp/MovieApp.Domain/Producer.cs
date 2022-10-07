using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain
{
    public class Producer
    {
        public string ProducerName { get; set; }
        public DateTime DOB { get; set; }
        public Producer(string producerName, DateTime dOB)
        {
            ProducerName = producerName;
            DOB = dOB;
        }
    }
}
