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
        User CreateOrEditUser(User user);
        User CreateUser(User user);
        User UpdateUser(User user);
        void DeleteUser(int userId);
        User GetUserById(int userId);
        User CreateOrEditUserAddress(int userId, List<AddressUser> addresses);
    }
}
