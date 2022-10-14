using Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ActorRepository : IActorRepository
    {
        private readonly List<Actor> _actors;
        public ActorRepository()
        {
            _actors = new List<Actor>();
        }

        public void SetActorToList(Actor actor)
        {
            _actors.Add(actor);
        }

        public int ActorId()
        {
            if(_actors.Count == 0)
            {
                return 1;
            }
            else 
            {
                return _actors[_actors.Count - 1].Id + 1;
            }
        }
        public List<Actor> GetActorsFromList()
        {
            return _actors.ToList();
        }
    }
}
