using ModulosUsuario.Contexts;
using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ModulosUsuario.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly DatabaseContext context;
        public StockRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public IEnumerable<Stock> GetAll()
        {
            return context.Stock.Include(i => i.Branch).ToList();
        }

        public Stock Create(Stock stock)
        {
            context.Add(stock);
            context.SaveChanges();
            return stock;
        }

        public Stock GetById(int stockId)
        {
            var stock = context.Stock.Where(w => w.StockId == stockId).Include(i => i.Branch).FirstOrDefault();
            if (stock == null)
                stock = new Stock();
            return stock;
        }

        public IEnumerable<StockProductViewModel> GetProductsById(int stockId)
        {
            return context.ProductTransaction
                .Include(i => i.TransactionType)
                .Select(pt => new { pt.ProductId, pt.StockId, pt.TransactionType, pt.Quantity, pt.UnityValue, pt.Product.Name })
                .Where(w => w.StockId == stockId)
                .GroupBy(x => new { x.ProductId, x.StockId, x.Name })
                .Select(g => new StockProductViewModel
                {
                    ProductId = g.Key.ProductId,
                    StockId = g.Key.StockId,
                    ProductName = g.Key.Name,
                    StockQuantity = g.Sum(s => s.TransactionType.IsIncoming ? s.Quantity : 0) - g.Sum(s => !s.TransactionType.IsIncoming ? s.Quantity : 0),
                    AverageCost = g.Sum(s => s.TransactionType.IsIncoming ? s.Quantity * s.UnityValue : 0) / g.Sum(s => s.TransactionType.IsIncoming ? s.Quantity : 0)
                });
        }

        public IEnumerable<StockMaterialViewModel> GetMaterialsById(int stockId)
        {
            return context.MaterialTransaction
                .Include(i => i.TransactionType)
                .Select(pt => new { pt.MaterialId, pt.StockId, pt.TransactionType, pt.Quantity, pt.UnityValue, pt.Material.Name })
                .Where(w => w.StockId == stockId)
                .GroupBy(x => new { x.MaterialId, x.StockId, x.Name })
                .Select(g => new StockMaterialViewModel
                {
                    MaterialId = g.Key.MaterialId,
                    StockId = g.Key.StockId,
                    MaterialName = g.Key.Name,
                    StockQuantity = g.Sum(s => s.TransactionType.IsIncoming ? s.Quantity : 0) - g.Sum(s => !s.TransactionType.IsIncoming ? s.Quantity : 0),
                    AverageCost = g.Sum(s => s.TransactionType.IsIncoming ? s.Quantity * s.UnityValue : 0) / g.Sum(s => s.TransactionType.IsIncoming ? s.Quantity : 0)
                });
        }

        public IEnumerable<StockToolViewModel> GetToolsById(int stockId)
        {
            return context.ToolsTransaction
                .Include(i => i.TransactionType)
                .Select(pt => new { pt.ToolId, pt.StockId, pt.TransactionType, pt.Quantity, pt.UnityValue, pt.Tool.Name })
                .Where(w => w.StockId == stockId)
                .GroupBy(x => new { x.ToolId, x.StockId, x.Name })
                .Select(g => new StockToolViewModel
                {
                    ToolId = g.Key.ToolId,
                    StockId = g.Key.StockId,
                    ToolName = g.Key.Name,
                    StockQuantity = g.Sum(s => s.TransactionType.IsIncoming ? s.Quantity : 0) - g.Sum(s => !s.TransactionType.IsIncoming ? s.Quantity : 0),
                    AverageCost = g.Sum(s => s.TransactionType.IsIncoming ? s.Quantity * s.UnityValue : 0) / g.Sum(s => s.TransactionType.IsIncoming ? s.Quantity : 0)
                });
        }
        
        public StockProductViewModel GetProductInStockById(int stockId,int productId)
        {
            return GetProductsById(stockId).Where(w => w.ProductId == productId).FirstOrDefault();
        }

        public StockMaterialViewModel GetMaterialInStockById(int stockId, int materialId)
        {
            return GetMaterialsById(stockId).Where(w => w.MaterialId == materialId).FirstOrDefault();
        }
    }
}