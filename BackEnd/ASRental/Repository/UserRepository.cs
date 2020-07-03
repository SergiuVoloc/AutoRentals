﻿using ASRental.Data;
using ASRental.Models;
using ASRental.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
