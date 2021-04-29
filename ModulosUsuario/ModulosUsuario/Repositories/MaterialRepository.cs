using ModulosUsuario.Contexts;
using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModulosUsuario.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly DatabaseContext context;
        public MaterialRepository(DatabaseContext context) 
        {
            this.context = context;
        }

        public Material Create(Material material)
        {
            context.Add(material);
            context.SaveChanges();
            return material;
        }

        public IEnumerable<Material> GetAll()
        {
            return context.Material.ToList(); 
        }

        public Material Update(Material material)
        {
            context.Update(material);
            context.SaveChanges();
            return material;
        }

        public void Delete(Material material)
        {
            material.Active = false;
            context.Update(material);
            context.SaveChanges();
        }

        public Material GetById(int materialId)
        {
            return context.Material.Find(materialId);
        }
    }
}
