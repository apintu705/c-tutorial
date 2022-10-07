﻿using MovieApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Interfaces
{
    public interface IActorService
    {
        void AddActor(string actorName, DateTime dOB);
        List<Actor> GetActors();
    }
}
