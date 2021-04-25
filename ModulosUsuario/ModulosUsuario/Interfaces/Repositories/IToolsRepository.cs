using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Repositories
{
    public interface IToolsRepository
    {
        IEnumerable<Tools> GetAll();
        Tools Create(Tools tools);

        Tools Update(Tools tools);

        Tools GetById(int toolsId);

        void Delete(Tools tools);
    }
}
