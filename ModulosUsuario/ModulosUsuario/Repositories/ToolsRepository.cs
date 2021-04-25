using ModulosUsuario.Contexts;
using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModulosUsuario.Repositories
{
    public class ToolsRepository : IToolsRepository
    {
        private readonly DatabaseContext context;
        public ToolsRepository(DatabaseContext context) 
        {
            this.context = context;
        }

        public Tools Create(Tools tools)
        {
            context.Add(tools);
            context.SaveChanges();
            return tools;
        }

        public IEnumerable<Tools> GetAll()
        {
            return context.Tools.ToList(); 
        }

        public Tools Update(Tools tools)
        {
            context.Update(tools);
            context.SaveChanges();
            return tools;
        }

        public void Delete(Tools tools)
        {
            context.Remove(tools);
            context.SaveChanges();
        }

        public Tools GetById(int toolsId)
        {
            var tools = context.Tools.Find(toolsId);
            if(tools == null)
                tools = new Tools();
            return tools;
        }
    }
}
