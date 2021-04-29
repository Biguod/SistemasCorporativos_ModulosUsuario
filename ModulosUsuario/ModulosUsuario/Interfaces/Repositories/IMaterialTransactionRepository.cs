using ModulosUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModulosUsuario.Interfaces.Repositories
{
    public interface IMaterialTransactionRepository
    {
        IEnumerable<MaterialTransaction> GetAll();

        MaterialTransaction Create(MaterialTransaction materialTransaction);

        IEnumerable<MaterialTransaction> GetByMaterialId(int materialId);

        MaterialTransaction GetById(int materialTransactionId);
    }
}
