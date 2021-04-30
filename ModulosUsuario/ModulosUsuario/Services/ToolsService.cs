using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Services
{
    public class ToolsService : IToolsService
    {
        public readonly IToolsRepository toolsRepository;
        public ToolsService(IToolsRepository toolsRepository)
        {
            this.toolsRepository = toolsRepository;
        }

        public IEnumerable<Tools> GetTools()
        {
            return toolsRepository.GetAll();
        }

        public void DeleteTools(int toolsId)
        {
            var tools = toolsRepository.GetById(toolsId);
            if (tools.ToolsId == 0)
                return; //throw exception aqui !!!

            toolsRepository.Delete(tools);
        }

        public Tools GetToolsById(int toolsId)
        {
            var tools = toolsRepository.GetById(toolsId);
            
            return tools;
        }

        public Tools CreateOrEditTools(Tools tools)
        {
            if(tools.ToolsId == 0)
            {
                return CreateTools(tools);
            }
            return UpdateTools(tools);
        }

        private Tools CreateTools(Tools tools)
        {
            return toolsRepository.Create(tools);
        }

        private Tools UpdateTools(Tools tools)
        {
            return toolsRepository.Update(tools);
        }
    }
}
