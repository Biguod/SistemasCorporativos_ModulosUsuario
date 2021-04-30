using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModulosUsuario.Services
{
    public class TransactionService : ITransactionService
    {
        public readonly IStockRepository stockRepository;
        public readonly IProductTransactionRepository productTransactionRepository;
        public readonly IMaterialTransactionRepository materialTransactionRepository;
        public readonly IToolsTransactionRepository toolsTransactionRepository;
        public readonly ITransactionTypeRepository transactionTypeRepository;

        public TransactionService(IStockRepository stockRepository,
            IProductTransactionRepository productTransactionRepository,
            IMaterialTransactionRepository materialTransactionRepository,
            IToolsTransactionRepository toolsTransactionRepository,
            ITransactionTypeRepository transactionTypeRepository)
        {
            this.stockRepository = stockRepository;
            this.productTransactionRepository = productTransactionRepository;
            this.materialTransactionRepository = materialTransactionRepository;
            this.toolsTransactionRepository = toolsTransactionRepository;
            this.transactionTypeRepository = transactionTypeRepository;
        }

        public IEnumerable<TransactionListViewModel> GetTransactionsList()
        {
            return stockRepository.GetAll().Select(s => new TransactionListViewModel
            {
                Stock = s,
                TotalProductTransactions = productTransactionRepository.GetByStockId(s.StockId).Count(),
                TotalMaterialTransactions = materialTransactionRepository.GetByStockId(s.StockId).Count(),
                TotalToolsTransactions = toolsTransactionRepository.GetByStockId(s.StockId).Count(),
            });
        }

        public TransactionsViewModel GetTransactionsByStock(int stockId)
        {
            return new TransactionsViewModel
            {
                Stock = stockRepository.GetById(stockId),
                ProductTransactions = productTransactionRepository.GetByStockId(stockId).ToList(),
                MaterialTransactions = materialTransactionRepository.GetByStockId(stockId).ToList(),
                ToolsTransactions = toolsTransactionRepository.GetByStockId(stockId).ToList(),
            };
        }

        public IEnumerable<TransactionType> GetTransactionTypeList()
        {
            return transactionTypeRepository.GetAll();
        }

        public ProductTransaction CreateProductTransaction(ProductTransaction productTransaction)
        {
            productTransaction = productTransactionRepository.Create(productTransaction);
            productTransaction = productTransactionRepository.GetById(productTransaction.ProductTransactionId);
            return productTransaction;
        }

        public MaterialTransaction CreateMaterialTransaction(MaterialTransaction materialTransaction)
        {
            materialTransaction = materialTransactionRepository.Create(materialTransaction);
            materialTransaction = materialTransactionRepository.GetById(materialTransaction.MaterialTransactionId);
            return materialTransaction;
        }

        public ToolsTransaction CreateToolTransaction(ToolsTransaction toolsTransaction)
        {
            toolsTransaction = toolsTransactionRepository.Create(toolsTransaction);
            toolsTransaction = toolsTransactionRepository.GetById(toolsTransaction.ToolsTransactionId);
            return toolsTransaction;
        }
    }
}
