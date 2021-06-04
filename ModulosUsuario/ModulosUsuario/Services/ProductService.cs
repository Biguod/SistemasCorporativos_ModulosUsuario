using Microsoft.AspNetCore.Hosting;
using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ModulosUsuario.Services
{
    public class ProductService : IProductService
    {
        public readonly IProductRepository productRepository;
        public readonly IProductTransactionRepository productTransactionRepository;
        public readonly ITransactionService transactionService;
        public readonly IStockService stockService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductService(IProductRepository productRepository,
            IProductTransactionRepository productTransactionRepository,
            ITransactionService transactionService,
            IStockService stockService,
            IWebHostEnvironment webHostEnvironment)
        {
            this.productRepository = productRepository;
            this.productTransactionRepository = productTransactionRepository;
            this.transactionService = transactionService;
            this.stockService = stockService;
            this.webHostEnvironment = webHostEnvironment;
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
            string uniqueFileName = UploadedFile(product);
            product.ProductImage = uniqueFileName;
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

        private string UploadedFile(Product product)
        {
            string uniqueFileName = product.ProductImage;

            if (product.ProductImageFile != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "img\\uploaded\\products");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + product.ProductImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    product.ProductImageFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}