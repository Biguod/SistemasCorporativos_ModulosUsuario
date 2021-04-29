using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Services
{
    public interface IMaterialService
    {
        IEnumerable<Material> GetMaterials();
        Material CreateOrEditMaterial(Material material);
        void DeleteMaterial(int materialId);
        Material GetMaterialById(int materialId);
        IEnumerable<MaterialTransaction> GetMaterialTransactions();
        MaterialTransaction CreateMaterialTransaction(MaterialTransaction materialTransaction);
        MaterialTransaction GetByMaterialTransactionId(int materialTransactionId);
        IEnumerable<MaterialTransaction> GetTransactionByMaterialId(int materialId);
    }
}
