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
            if (userRepository.GetByLogin(user.Login) != null)
                return user; //throw exception aqui!!

            userRepository.Create(user);
            return user;
        }

        public User UpdateUser(User user)
        {
            userRepository.Update(user);
            return user;
        }

        public void DeleteUser(int userId)
        {
            var user = userRepository.GetById(userId);
            if (user.UserId == 0)
                return; //throw exception aqui !!!

            userRepository.DeleteUser(user);
        }

        public User GetUserById(int userId)
        {
            var user = userRepository.GetById(userId);
            
            return user;
        }

        public User CreateOrEditUser(User user)
        {
            if(user.UserId == 0)
            {
                return CreateUser(user);
            }
            return UpdateUser(user);
        }

        public User CreateOrEditUserAddress(int userId, List<AddressUser> addresses)
        {
            var currentUser = userRepository.GetById(userId);
            currentUser.Addresses = addresses;
            return UpdateUser(currentUser);
        }

        //public User SetUserPermission(User user, int userPermission)
        //{
        //    if (userPermission != 1)
        //        return user; //Throws exception
        //    userRepository.Update(user);
        //    return user;
        //}
    }
}
