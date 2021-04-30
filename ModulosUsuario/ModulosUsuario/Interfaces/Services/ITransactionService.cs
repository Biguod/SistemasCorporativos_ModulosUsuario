using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Services
{
    public interface ITransactionService
    {
        IEnumerable<TransactionListViewModel> GetTransactionsList();
        IEnumerable<TransactionType> GetTransactionTypeList();
        TransactionsViewModel GetTransactionsByStock(int stockId);
        ProductTransaction CreateProductTransaction(ProductTransaction productTransaction);
        MaterialTransaction CreateMaterialTransaction(MaterialTransaction materialTransaction);
        ToolsTransaction CreateToolTransaction(ToolsTransaction toolsTransaction);
    }
}
