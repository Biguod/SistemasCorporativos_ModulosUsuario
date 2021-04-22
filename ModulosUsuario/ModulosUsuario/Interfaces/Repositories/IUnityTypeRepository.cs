using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Repositories
{
    public interface IUnityTypeRepository
    {
        IEnumerable<UnityType> GetAll();
        UnityType Create(UnityType unityType);

        UnityType Update(UnityType unityType);

        UnityType GetById(int unityTypeId);

        void Delete(UnityType unityType);
    }
}
