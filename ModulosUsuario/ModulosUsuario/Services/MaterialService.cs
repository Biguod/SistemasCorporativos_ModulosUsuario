using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Services
{
    public class MaterialService : IMaterialService
    {
        public readonly IMaterialRepository materialRepository;
        public MaterialService(IMaterialRepository materialRepository)
        {
            this.materialRepository = materialRepository;
        }

        public IEnumerable<Material> GetMaterials()
        {
            return materialRepository.GetAll();
        }

        public void DeleteMaterial(int materialId)
        {
            var material = materialRepository.GetById(materialId);
            if (material.MaterialId == 0)
                return; //throw exception aqui !!!

            materialRepository.Delete(material);
        }

        public Material GetMaterialById(int materialId)
        {
            var material = materialRepository.GetById(materialId);
            
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
    }
}
