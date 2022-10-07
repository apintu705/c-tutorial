using MovieApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Repository
{
    public class ActorRepository
    {
        private readonly static List<Actor> _actors = new List<Actor>();


        public static void SetActorToList(Actor actor)
        {
            _actors.Add(actor);
        }

        public static List<Actor> GetActorsFromList()
        {
            return _actors.ToList();
        }
    }
}
