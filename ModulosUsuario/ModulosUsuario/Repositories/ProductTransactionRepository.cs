using ModulosUsuario.Contexts;
using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return context.ProductTransaction.Find(productTransactionId);
        }

        public IEnumerable<ProductTransaction> GetByProductId(int productId)
        {
            return context.ProductTransaction.Where(w => w.ProductId == productId).ToList();
        }
    }
}
