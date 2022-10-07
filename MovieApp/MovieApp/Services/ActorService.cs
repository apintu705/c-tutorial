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
    public class ActorService : IActorService
    {
        public void AddActor(string actorName, DateTime dOB)
        {
            if (string.IsNullOrEmpty(actorName))
            {
                throw new ArgumentException("Invalid arguments");
            }

            ActorRepository.SetActorToList(new Domain.Actor(actorName, dOB));
        }

        public List<Actor> GetActors()
        {
            return ActorRepository.GetActorsFromList();
        }
    }
}
