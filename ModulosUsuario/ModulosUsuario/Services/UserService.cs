using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ModulosUsuario.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetAll();
        }

        public User CreateUser(User user)
        {
            //Login não pode ser repetido
            if (userRepository.GetByLogin(user.Login).UserId > 0)
                return user; //throw exception aqui!!

            //user = new User { UserId = 0, Login = "testando", Password = "Senha", Email = "b@b.com", Name = "Bigu", LastName = "Linha", BirthDate = DateTime.Now, CPF = "526648244" };


            userRepository.Create(user);
            return user;
        }

        public User UpdateUser(User user)
        {
            userRepository.Update(user);
            return user;
        }

        public void DeleteUser(User user)
        {
            if (userRepository.GetById(user.UserId).UserId <= 0)
                return; //throw exception aqui !!!

            userRepository.DeleteUser(user);
        }
    }
}
