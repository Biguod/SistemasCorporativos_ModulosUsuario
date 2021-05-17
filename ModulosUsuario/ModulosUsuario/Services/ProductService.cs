using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModulosUsuario.Services
{
    public class ProductService : IProductService
    {
        public readonly IProductRepository productRepository;
        public readonly IProductTransactionRepository productTransactionRepository;
        public readonly ITransactionService transactionService;
        public readonly IStockService stockService;
        public ProductService(IProductRepository productRepository, 
            IProductTransactionRepository productTransactionRepository, 
            ITransactionService transactionService, 
            IStockService stockService)
        {
            this.productRepository = productRepository;
            this.productTransactionRepository = productTransactionRepository;
            this.transactionService = transactionService;
            this.stockService = stockService;
        }

        public IEnumerable<Product> GetProducts()
        {
            return productRepository.GetAll().Where(w => w.Active);
        }

        public void DeleteProduct(int productId)
        {
            var product = GetProductById(productId);
            if (product.Active == false)
                return; //throw exception aqui !!!

            productRepository.Delete(product);
        }

        public Product GetProductById(int productId)
        {
            var product = productRepository.GetById(productId);
            if (product == null)
                product = new Product();
            return product;
        }

        public Product CreateOrEditProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                //Console.WriteLine(product);
                return CreateProduct(product);
            }
            return UpdateProduct(product);
        }

        private Product CreateProduct(Product product)
        {
            return productRepository.Create(product); ;
        }

        private Product UpdateProduct(Product product)
        {
            return productRepository.Update(product); ;
        }

        public IEnumerable<ProductTransaction> GetProductTransactions()
        {
            return productTransactionRepository.GetAll();
        }

        public ProductTransaction GetByProductTransactionId(int productTransactionId)
        {
            var productTransaction = productTransactionRepository.GetById(productTransactionId);
            if (productTransaction == null)
                productTransaction = new ProductTransaction();
            return productTransaction;
        }

        public IEnumerable<ProductTransaction> GetTransactionsByProductId(int productId)
        {
            return productTransactionRepository.GetByProductId(productId);
        }

        //private IEnumerable<ProductTransaction> GetIncomingTransaction(int stockId, int productId)
        //{
        //    return productTransactionRepository.GetAll().Where(w => w.StockId == stockId && w.ProductId == productId && w.TransactionTypeId <= 4).ToList();
        //}

        //private IEnumerable<ProductTransaction> GetOutcomingTransaction(int stockId, int productId)
        //{
        //    return productTransactionRepository.GetAll().Where(w => w.StockId == stockId && w.ProductId == productId && w.TransactionTypeId >= 5).ToList();
        //}

        //public StockProductViewModel GetProductStock(ProductTransaction productTransaction)
        //{
        //    var income = GetIncomingTransaction(productTransaction.StockId, productTransaction.ProductId).Count();
        //}
    }
}
