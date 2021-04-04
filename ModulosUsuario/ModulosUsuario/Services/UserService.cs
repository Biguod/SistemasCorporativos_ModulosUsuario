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


            //var useradresses = new Collection<AddressUser>();
            //var address = new AddressUser { AddressId = 1, Street = "Saldanha", Number = "825", PostalCode = "80410151", StateId = 1, CityId = 1, District = "Centro" };
            //useradresses.Add(address);
            //var user = new User { Id = 2, Login = "testando", Senha = "Senha", Email = "b@b.com", Name = "Bigu", LastName = "Linha", BirthDate = DateTime.Now, CPF = "526648244", Addresses = useradresses };

            user = new User { UserId = 0, Login = "testando", Password = "Senha", Email = "b@b.com", Name = "Bigu", LastName = "Linha", BirthDate = DateTime.Now, CPF = "526648244" };


            userRepository.Create(user);
            return user;
        }

        public User UpdateUser(User user)
        {
            userRepository.Update(user);
            return user;
        }
    }
}
