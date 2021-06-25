using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModulosUsuario.Services
{
    public class SaleService : ISaleService
    {
        public readonly IStockService stockService;
        public readonly IProductService productService;
        public readonly IProductTransactionRepository productTransactionRepository;
        public readonly ITransactionService transactionService;
        public readonly ISaleRepository saleRepository;

        public SaleService(IStockService stockService,
            IProductTransactionRepository productTransactionRepository,
            IProductService productService,
            ITransactionService transactionService,
            ISaleRepository saleRepository)
        {
            this.stockService = stockService;
            this.productTransactionRepository = productTransactionRepository;
            this.productService = productService;
            this.transactionService = transactionService;
            this.saleRepository = saleRepository;
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

        public void ReserveProduct(SaleViewModel model) //Chamado quando colocar no carrinho // Criar objeto carrinho (ViewModel) SaleViewModel
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
            productTransaction = transactionService.CreateProductTransaction(productTransaction);

            var sale = new Sale
            {
                CreateDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(1),
                Quantity = model.Quantity,
                SaleId = 0,
                Status = "Reservado",
                TotalPrice = model.AverageCost * model.Quantity,
                ProductTransactionId = productTransaction.ProductTransactionId
            };

            CreateSale(sale);
        }

        private void CreateSale(Sale sale)
        {
            saleRepository.Create(sale);
        }
        private void UpdateSale(Sale sale)
        {
            saleRepository.Update(sale);
        }

        public void CancelReservedSale(int productTransactionId)
        {
            var productTransactionReserved = transactionService.GetProductTransaction(productTransactionId);
            var productTransactionreservedCanceled = new ProductTransaction
            {
                ProductId = productTransactionReserved.ProductId,
                ProductTransactionId = 0,
                Quantity = productTransactionReserved.Quantity,
                StockId = productTransactionReserved.StockId,
                TransactionTypeId = transactionService.GetTransactionTypeByDescription("Reserva Cancelada").TransactionTypeId,
                UnityValue = productTransactionReserved.UnityValue,
                UserId = productTransactionReserved.UserId
            };

            transactionService.CreateProductTransaction(productTransactionreservedCanceled);

            var sale = saleRepository.GetByProductTransactionId(productTransactionId);
            sale.ExpirationDate = null;
            sale.Status = "Reserva Cancelada";

            UpdateSale(sale);
        }

        public ShopCartViewModel GetCartByCustomer(int customerId)
        {
            ///pegar da sale onde status é reservado e userid é o cara
            ///
            var salesByCustomer = saleRepository.GetAllReservedByUserId(customerId);

            return new ShopCartViewModel
            {
                Products = salesByCustomer,
                TotalPrice = salesByCustomer.Sum(s => s.TotalPrice)
            };
        }
    }
}