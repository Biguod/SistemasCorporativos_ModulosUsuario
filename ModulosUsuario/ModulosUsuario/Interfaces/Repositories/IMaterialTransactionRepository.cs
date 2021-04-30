using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Repositories
{
    public interface IMaterialTransactionRepository
    {
        IEnumerable<MaterialTransaction> GetAll();

        MaterialTransaction Create(MaterialTransaction materialTransaction);

        IEnumerable<MaterialTransaction> GetByMaterialId(int materialId);

        MaterialTransaction GetById(int materialTransactionId);

        IEnumerable<MaterialTransaction> GetByStockId(int stockId);
    }
}
