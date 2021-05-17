using Microsoft.EntityFrameworkCore;
using ModulosUsuario.Contexts;
using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModulosUsuario.Repositories
{
    public class MaterialTransactionRepository : IMaterialTransactionRepository
    {
        private readonly DatabaseContext context;

        public MaterialTransactionRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public MaterialTransaction Create(MaterialTransaction materialTransaction)
        {
            context.Add(materialTransaction);
            context.SaveChanges();
            return materialTransaction;
        }

        public IEnumerable<MaterialTransaction> GetAll()
        {
            return context.MaterialTransaction.ToList();
        }

        public MaterialTransaction GetById(int materialTransactionId)
        {
            return context.MaterialTransaction
                .Where(w => w.MaterialTransactionId == materialTransactionId)
                .Include(i => i.Stock)
                .Include(i => i.Material)
                .Include(i => i.TransactionType)
                .Include("Stock.Branch")
                .FirstOrDefault();
        }

        public IEnumerable<MaterialTransaction> GetByMaterialId(int materialId)
        {
            return context.MaterialTransaction
                .Where(w => w.MaterialId == materialId)
                .Include(i => i.Stock)
                .Include(i => i.Material)
                .Include(i => i.TransactionType)
                .ToList();
        }

        public IEnumerable<MaterialTransaction> GetByStockId(int stockId)
        {
            return context.MaterialTransaction
                .Where(w => w.StockId == stockId)
                .Include(i => i.Stock)
                .Include(i => i.Material)
                .Include(i => i.TransactionType)
                .ToList();
        }
    }
}
