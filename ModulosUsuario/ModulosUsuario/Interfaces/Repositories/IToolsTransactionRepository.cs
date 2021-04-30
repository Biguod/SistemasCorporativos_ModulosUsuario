using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Repositories
{
    public interface IToolsTransactionRepository
    {
        IEnumerable<ToolsTransaction> GetAll();

        ToolsTransaction Create(ToolsTransaction toolsTransaction);

        IEnumerable<ToolsTransaction> GetByToolsId(int toolsId);

        ToolsTransaction GetById(int toolsTransactionId);

        IEnumerable<ToolsTransaction> GetByStockId(int stockId);

    }
}