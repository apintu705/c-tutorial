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
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        public ActorService()
        {
            _actorRepository = new ActorRepository();
        }
        public void AddActor(string actorName, DateTime dOB)
        {
            if (string.IsNullOrEmpty(actorName))
            {
                throw new ArgumentException("Invalid arguments");
            }

            int id = _actorRepository.ActorId();
            _actorRepository.SetActorToList(new Domain.Actor(actorName, dOB, id));
        }

        public List<Actor> GetActors()
        {
            return _actorRepository.GetActorsFromList();
        }
    }
}
