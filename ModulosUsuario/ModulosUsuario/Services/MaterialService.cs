using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Services
{
    public class MaterialService : IMaterialService
    {
        public readonly IMaterialRepository materialRepository;
        public readonly IMaterialTransactionRepository materialTransactionRepository;
        public MaterialService(IMaterialRepository materialRepository, IMaterialTransactionRepository materialTransactionRepository)
        {
            this.materialRepository = materialRepository;
            this.materialTransactionRepository = materialTransactionRepository;
        }

        public IEnumerable<Material> GetMaterials()
        {
            return materialRepository.GetAll();
        }

        public void DeleteMaterial(int materialId)
        {
            var material = materialRepository.GetById(materialId);
            if (material.Active == false)
                return; //throw exception aqui !!!

            materialRepository.Delete(material);
        }

        public Material GetMaterialById(int materialId)
        {
            var material = materialRepository.GetById(materialId);
            if (material == null)
                material = new Material();
            return material;
        }

        public Material CreateOrEditMaterial(Material material)
        {
            if(material.MaterialId == 0)
            {
                return CreateMaterial(material);
            }
            return UpdateMaterial(material);
        }

        private Material CreateMaterial(Material material)
        {
            materialRepository.Create(material);
            return material;
        }

        private Material UpdateMaterial(Material material)
        {
            materialRepository.Update(material);
            return material;
        }

        public IEnumerable<MaterialTransaction> GetMaterialTransactions()
        {
            return materialTransactionRepository.GetAll();
        }

        public MaterialTransaction CreateMaterialTransaction(MaterialTransaction materialTransaction)
        {
            materialTransactionRepository.Create(materialTransaction);
            return materialTransaction;
        }

        public MaterialTransaction GetByMaterialTransactionId(int materialTransactionId)
        {
            var materialTransaction = materialTransactionRepository.GetById(materialTransactionId);
            if (materialTransaction == null)
                materialTransaction = new MaterialTransaction();
            return materialTransaction;
        }

        public IEnumerable<MaterialTransaction> GetTransactionByMaterialId(int materialId)
        {
            return materialTransactionRepository.GetByMaterialId(materialId);
        }
    }
}
