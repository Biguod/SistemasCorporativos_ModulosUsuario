using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Services
{
    public interface IToolsService
    {
        IEnumerable<Tools> GetTools();
        Tools CreateOrEditTools(Tools tools);
        void DeleteTools(int toolsId);
        Tools GetToolsById(int toolsId);
    }
}
