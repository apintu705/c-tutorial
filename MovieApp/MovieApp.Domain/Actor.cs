using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain
{
    public class Actor
    {
        public string ActorName { get; set; }
        public DateTime DOB { get; set; }

        public Actor(string actorName, DateTime dOB)
        {
            ActorName = actorName;
            DOB = dOB;
        }
    }
}
