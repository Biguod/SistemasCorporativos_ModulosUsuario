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
    }
}
