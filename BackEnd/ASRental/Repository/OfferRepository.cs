﻿using ASRental.Data;
using ASRental.Models;
using ASRental.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Repository
{
    public class OfferRepository : RepositoryBase<Offer>, IOfferRepository
    {
        public OfferRepository(ApplicationDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
