using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Repositories
{
    public interface ITransactionTypeRepository
    {
        IEnumerable<TransactionType> GetAll();
    }
}
