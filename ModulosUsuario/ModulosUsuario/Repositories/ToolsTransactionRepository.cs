using Microsoft.EntityFrameworkCore;
using ModulosUsuario.Contexts;
using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModulosUsuario.Repositories
{
    public class ToolsTransactionRepository : IToolsTransactionRepository
    {
        private readonly DatabaseContext context;

        public ToolsTransactionRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public ToolsTransaction Create(ToolsTransaction toolsTransaction)
        {
            context.Add(toolsTransaction);
            context.SaveChanges();
            return toolsTransaction;
        }

        public IEnumerable<ToolsTransaction> GetAll()
        {
            return context.ToolsTransaction.ToList();
        }

        public ToolsTransaction GetById(int toolsTransactionId)
        {
            return context.ToolsTransaction
                .Where(w => w.ToolsTransactionId == toolsTransactionId)
                .Include(i => i.Stock)
                .Include(i => i.Tool)
                .Include(i => i.TransactionType)
                .FirstOrDefault();
        }

        public IEnumerable<ToolsTransaction> GetByStockId(int stockId)
        {
            return context.ToolsTransaction
                .Where(w => w.StockId == stockId)
                .Include(i => i.Stock)
                .Include(i => i.Tool)
                .Include(i => i.TransactionType)
                .ToList();
        }

        public IEnumerable<ToolsTransaction> GetByToolsId(int toolsId)
        {
            return context.ToolsTransaction
                .Where(w => w.ToolId == toolsId)
                .Include(i => i.Stock)
                .Include(i => i.Tool)
                .Include(i => i.TransactionType)
                .ToList();
        }
    }
}
