using ModulosUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModulosUsuario.Interfaces.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Create(User user);

        User Update(User user);

        User GetByLogin(string login);

        User GetById(int userId);

        void DeleteUser(User user);
    }
}
