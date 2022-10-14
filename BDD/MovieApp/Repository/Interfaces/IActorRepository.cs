using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IActorRepository
    {
        void SetActorToList(Actor actor);
        int ActorId();
        List<Actor> GetActorsFromList();
    }
}
