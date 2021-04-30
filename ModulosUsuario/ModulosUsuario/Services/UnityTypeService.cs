using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Services
{
    public class UnityTypeService : IUnityTypeService
    {
        public readonly IUnityTypeRepository unityTypeRepository;
        public UnityTypeService(IUnityTypeRepository unityTypeRepository)
        {
            this.unityTypeRepository = unityTypeRepository;
        }

        public IEnumerable<UnityType> GetUnityTypes()
        {
            return unityTypeRepository.GetAll();
        }

        public void DeleteUnityType(int unityTypeId)
        {
            var unityType = unityTypeRepository.GetById(unityTypeId);
            if (unityType.UnityTypeId == 0)
                return; //throw exception aqui !!!

            unityTypeRepository.Delete(unityType);
        }

        public UnityType GetUnityTypeById(int unityTypeId)
        {
            var unityType = unityTypeRepository.GetById(unityTypeId);
            
            return unityType;
        }

        public UnityType CreateOrEditUnityType(UnityType unityType)
        {
            if(unityType.UnityTypeId == 0)
            {
                return CreateUnityType(unityType);
            }
            return UpdateUnityType(unityType);
        }

        private UnityType CreateUnityType(UnityType unityType)
        {
            return unityTypeRepository.Create(unityType);
        }

        private UnityType UpdateUnityType(UnityType unityType)
        {
            return unityTypeRepository.Update(unityType); ;
        }
    }
}
