using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Services
{
    public class SaleService : ISaleService
    {
        public readonly IStockService stockService;
        public readonly IProductService productService;
        public readonly IProductTransactionRepository productTransactionRepository;
        public readonly ITransactionService transactionService;

        public SaleService(IStockService stockService,
            IProductTransactionRepository productTransactionRepository,
            IProductService productService,
            ITransactionService transactionService)
        {
            this.stockService = stockService;
            this.productTransactionRepository = productTransactionRepository;
            this.productService = productService;
            this.transactionService = transactionService;
        }

        public IEnumerable<SaleListViewModel> GetAllProducts()
        {
            return productTransactionRepository.GetAllProductsForSale();
        }

        public SaleViewModel GetProductForSaleById(int stockId, int productId)
        {
            var result = stockService.GetProductInStockById(stockId, productId);
            return new SaleViewModel
            {
                Product = productService.GetProductById(productId),
                ProductId = productId,
                Stock = stockService.GetStockById(stockId),
                StockId = stockId,
                AverageCost = result.AverageCost,
                StockQuantity = result.StockQuantity,
                Quantity = 1
            };
        }

        public void ReserveProduct(SaleViewModel model)
        {
            var productTransaction = new ProductTransaction
            {
                ProductId = model.ProductId,
                ProductTransactionId = 0,
                Quantity = model.Quantity,
                StockId = model.StockId,
                TransactionTypeId = transactionService.GetTransactionTypeByDescription("Reserva").TransactionTypeId,
                UnityValue = model.AverageCost,
                UserId = model.UserId
            };
            transactionService.CreateProductTransaction(productTransaction);
        }

    }
}