using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public Producer(string producerName, DateTime dOB, int id)
        {
            Name = producerName;
            DOB = dOB;
            Id = id;    
        }
    }
}
