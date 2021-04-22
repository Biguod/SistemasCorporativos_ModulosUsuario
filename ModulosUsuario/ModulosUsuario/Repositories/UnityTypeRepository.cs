using ModulosUsuario.Contexts;
using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModulosUsuario.Repositories
{
    public class UnityTypeRepository : IUnityTypeRepository
    {
        private readonly DatabaseContext context;
        public UnityTypeRepository(DatabaseContext context) 
        {
            this.context = context;
        }

        public IEnumerable<UnityType> GetAll()
        {
            return context.UnityType.ToList();
        }

        public UnityType Create(UnityType unityType)
        {
            context.Add(unityType);
            context.SaveChanges();
            return unityType;
        }

        public UnityType Update(UnityType unityType)
        {
            context.Update(unityType);
            context.SaveChanges();
            return unityType;
        }

        public UnityType GetById(int unityTypeId)
        {
            var unityType = context.UnityType.Find(unityTypeId);
            if (unityType == null)
                unityType = new UnityType();
            return unityType;
        }

        public void Delete(UnityType unityType)
        {
            context.Remove(unityType);
            context.SaveChanges();
        }
    }
}
