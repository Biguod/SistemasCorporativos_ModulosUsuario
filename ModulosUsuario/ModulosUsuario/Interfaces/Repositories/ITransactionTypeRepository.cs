using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Repositories
{
    public interface ITransactionTypeRepository
    {
        IEnumerable<TransactionType> GetAll();
        TransactionType GetTransactionTypeById(int transactionTypeId);
        TransactionType GetTransactionTypeByDescription(string transactionTypeDescription);
    }
}
