using ModulosUsuario.Contexts;
using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModulosUsuario.Repositories
{
    public class TransactionTypeRepository : ITransactionTypeRepository
    {
        private readonly DatabaseContext context;
        public TransactionTypeRepository(DatabaseContext context) 
        {
            this.context = context;
        }

        public IEnumerable<TransactionType> GetAll()
        {
            return context.TransactionType.ToList();
        }

        public TransactionType GetTransactionTypeById(int transactionTypeId)
        {
            return context.TransactionType.Find(transactionTypeId);
        }

    }
}
