﻿using ModulosUsuario.Contexts;
using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModulosUsuario.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext context;
        public UserRepository(DatabaseContext context) 
        {
            this.context = context;
        }

        public User Create(User user)
        {
            context.Add(user);
            context.SaveChanges();
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User Update(User user)
        {
            context.Update(user);
            context.SaveChanges();
            return user;
        }
    }
}
