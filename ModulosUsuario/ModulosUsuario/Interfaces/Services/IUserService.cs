using ModulosUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModulosUsuario.Interfaces.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User CreateUser(User user);
        User UpdateUser(User user);
        void DeleteUser(User user);
        User GetUserById(int userId);
    }
}
