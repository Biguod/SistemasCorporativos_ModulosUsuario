using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Services
{
    public interface IUnityTypeService
    {
        IEnumerable<UnityType> GetUnityTypes();
        UnityType CreateOrEditUnityType(UnityType unityType);
        void DeleteUnityType(int unityTypeId);
        UnityType GetUnityTypeById(int unityTypeId);
    }
}
