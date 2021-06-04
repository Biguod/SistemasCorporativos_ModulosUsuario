using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using ModulosUsuario.Exceptions;

namespace ModulosUsuario.Services
{
    public class TransactionService : ITransactionService
    {
        public readonly IStockRepository stockRepository;
        public readonly IProductTransactionRepository productTransactionRepository;
        public readonly IMaterialTransactionRepository materialTransactionRepository;
        public readonly IToolsTransactionRepository toolsTransactionRepository;
        public readonly ITransactionTypeRepository transactionTypeRepository;
        public readonly IStockService stockService;

        public TransactionService(IStockRepository stockRepository,
            IProductTransactionRepository productTransactionRepository,
            IMaterialTransactionRepository materialTransactionRepository,
            IToolsTransactionRepository toolsTransactionRepository,
            ITransactionTypeRepository transactionTypeRepository,
            IStockService stockService)
        {
            this.stockRepository = stockRepository;
            this.productTransactionRepository = productTransactionRepository;
            this.materialTransactionRepository = materialTransactionRepository;
            this.toolsTransactionRepository = toolsTransactionRepository;
            this.transactionTypeRepository = transactionTypeRepository;
            this.stockService = stockService;
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
            try
            {
                var transactionType = GetTransactionTypeById(productTransaction.TransactionTypeId);
                var productInStock = stockService.GetProductInStockById(productTransaction.StockId, productTransaction.ProductId);
                if (!transactionType.IsIncoming && productInStock.StockQuantity < productTransaction.Quantity)
                {
                    throw new LesserStockException();
                }
                productTransaction = productTransactionRepository.Create(productTransaction);
                return productTransactionRepository.GetById(productTransaction.ProductTransactionId);
            }
            catch (LesserStockException ex)
            {
                throw new LesserStockException(ex.Message);
            }
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

        public ProductTransaction GetProductTransaction(int productTransactionId)
        {
            return productTransactionRepository.GetById(productTransactionId);
        }

        public ToolsTransaction GetToolTransaction(int toolsTransactionId)
        {
            return toolsTransactionRepository.GetById(toolsTransactionId);
        }
        public MaterialTransaction GetMaterialTransaction(int materialTransactionId)
        {
            return materialTransactionRepository.GetById(materialTransactionId);
        }
        public TransactionType GetTransactionTypeById(int transactionTypeId)
        {
            var transactionType = transactionTypeRepository.GetTransactionTypeById(transactionTypeId);
            if (transactionType == null)
            {
                throw new ArgumentNullException();
            }
            return transactionType;
        }
        public TransactionType GetTransactionTypeByDescription(string transactionTypeDescription)
        {
            var transactionType = transactionTypeRepository.GetTransactionTypeByDescription(transactionTypeDescription);
            if (transactionType == null)
            {
                throw new ArgumentNullException();
            }
            return transactionType;
        }
    }
}