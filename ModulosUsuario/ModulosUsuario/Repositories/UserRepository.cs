﻿using ModulosUsuario.Contexts;
using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Models;
using System.Collections.Generic;
using System.Linq;

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

        public User GetByLogin(string login)
        {
            return context.Users.Where(w => w.Login == login).FirstOrDefault();
        }

        public void DeleteUser(User user)
        {
            context.Remove(user);
            context.SaveChanges();
        }

        public User GetById(int userId)
        {
            var user = context.Users.Find(userId);
            if(user != null)
                context.Entry(user).Collection(c => c.Addresses).Load();
            else
                user = new User();
            if (user.Addresses == null)
                user.Addresses = new List<AddressUser>();
            return user;
        }
    }
}
