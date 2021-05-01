using Microsoft.EntityFrameworkCore;
using ModulosUsuario.Contexts;
using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModulosUsuario.Repositories
{
    public class ProductTransactionRepository : IProductTransactionRepository
    {
        private readonly DatabaseContext context;

        public ProductTransactionRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public ProductTransaction Create(ProductTransaction productTransaction)
        {
            context.Add(productTransaction);
            context.SaveChanges();
            return productTransaction;
        }

        public IEnumerable<ProductTransaction> GetAll()
        {
            return context.ProductTransaction.ToList();
        }

        public ProductTransaction GetById(int productTransactionId)
        {
            return context.ProductTransaction
                .Where(w => w.ProductTransactionId == productTransactionId)
                .Include(i => i.Stock)
                .Include(i => i.Product)
                .Include(i => i.TransactionType)
                .Include("Stock.Branch")
                .FirstOrDefault();
        }

        public IEnumerable<ProductTransaction> GetByProductId(int productId)
        {
            return context.ProductTransaction
                .Where(w => w.ProductId == productId)
                .Include(i => i.Stock)
                .Include(i => i.Product)
                .Include(i => i.TransactionType)
                .ToList();
        }

        public IEnumerable<ProductTransaction> GetByStockId(int stockId)
        {
            return context.ProductTransaction
                .Where(w => w.StockId == stockId)
                .Include(i => i.Stock)
                .Include(i => i.Product)
                .Include(i => i.TransactionType)
                .ToList();
        }
    }
}
