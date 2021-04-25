using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Repositories
{
    public interface IMaterialRepository
    {
        IEnumerable<Material> GetAll();
        Material Create(Material material);

        Material Update(Material material);

        Material GetById(int materialId);

        void Delete(Material material);
    }
}
