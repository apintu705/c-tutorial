﻿using MovieApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Interfaces
{
    public interface IProducerService
    {
        void AddProducer(string producerName, DateTime dOB);
        List<Producer> GetProducers();
    }
}
