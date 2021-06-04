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

        public IEnumerable<SaleListViewModel> GetAllProductsForSale()
        {
            return context.ProductTransaction
                .Include(i => i.TransactionType)
                .Where(w => w.Product.Active)
                .Select(pt => new { pt.ProductId, pt.StockId, pt.TransactionType, pt.Quantity, pt.UnityValue, pt.Product.Name, pt.Product.ProductImage })
                .GroupBy(x => new { x.ProductId, x.StockId, x.Name, x.ProductImage })
                .Select(g => new SaleListViewModel
                {
                    ProductId = g.Key.ProductId,
                    StockId = g.Key.StockId,
                    ProductName = g.Key.Name,
                    ProductImage = g.Key.ProductImage,
                    StockQuantity = g.Sum(s => s.TransactionType.IsIncoming ? s.Quantity : 0) - g.Sum(s => !s.TransactionType.IsIncoming ? s.Quantity : 0),
                    AverageCost = g.Sum(s => s.TransactionType.IsIncoming ? s.Quantity * s.UnityValue : 0) / g.Sum(s => s.TransactionType.IsIncoming ? s.Quantity : 0)
                });
        }
    }
}