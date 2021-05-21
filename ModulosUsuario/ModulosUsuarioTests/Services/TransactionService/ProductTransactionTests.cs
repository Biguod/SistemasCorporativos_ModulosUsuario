using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;
using ModulosUsuario.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModulosUsuarioTests.Services
{
    [TestFixture]
    class ProductTransactionTests
    {
        private TransactionService _transactionService;
        private Mock<IStockRepository> _stockRepository;
        private Mock<IProductTransactionRepository> _productTransactionRepository;
        private Mock<IMaterialTransactionRepository> _materialTransactionRepository;
        private Mock<IToolsTransactionRepository> _toolsTransactionRepository;
        private Mock<IStockService> _stockService;
        private Mock<ITransactionTypeRepository> _transactionTypeRepository;
        private Product _product;
        private Stock _stock;
        private TransactionType _transactionType;
        private ProductTransaction _productTransaction;
        


        [SetUp]
        public void SetUp()
        {
            _stockRepository = new Mock<IStockRepository>();
            _productTransactionRepository = new Mock<IProductTransactionRepository>();
            _materialTransactionRepository = new Mock<IMaterialTransactionRepository>();
            _toolsTransactionRepository = new Mock<IToolsTransactionRepository>();
            _transactionTypeRepository = new Mock<ITransactionTypeRepository>();
            _stockService = new Mock<IStockService>();


            _transactionService = new TransactionService(
                    _stockRepository.Object,
                    _productTransactionRepository.Object,
                    _materialTransactionRepository.Object,
                    _toolsTransactionRepository.Object,
                    _transactionTypeRepository.Object,
                    _stockService.Object);

            _product = new Product { ProductId = 1, SKU = "sku", Description = "description", Name = "Coca", DueDate = DateTime.Now, Unity = 10, UnityTypeId = 1, PriceList = 10, Active = true };
            _stock = new Stock { StockId = 1, BranchId = 1 };
            _transactionType = new TransactionType { TransactionTypeId = 1, Description = "Description", IsIncoming = true };

            _productTransaction = new ProductTransaction { ProductTransactionId = 1, ProductId = 1, Quantity = 10, UnityValue = 10, TransactionTypeId = 1, StockId = 1, Product = _product, Stock = _stock, TransactionType = _transactionType };
       
        }

        [Test]
        public void CreateProductTransaction_WhenCalled_ShouldReturnProductTransaction()
        {
            
            _productTransactionRepository.Setup(s => s.Create(_productTransaction)).Returns(_productTransaction);

            var transactionTypeId = _transactionTypeRepository.Setup(s => s.GetTransactionTypeById(1)).Returns(_transactionType);
            var productInStock = _stockService.Setup(s => s.GetProductInStockById(1, 1)).Returns(new StockProductViewModel()
                {
                    ProductId = 1,
                    ProductName = "Coca",
                    StockQuantity = 10,
                    AverageCost = 10,
                    StockId = 1
                });
            _productTransactionRepository.Setup(s => s.GetById(It.IsAny<int>())).Returns(_productTransaction);
            var result = _transactionService.CreateProductTransaction(_productTransaction);

            Assert.That(result, Is.Not.Null);
            var productTransactionResult = result as ProductTransaction;
            Assert.That(productTransactionResult, Is.InstanceOf<ProductTransaction>());
            _productTransactionRepository.Verify(v => v.GetById(It.IsAny<int>()), Times.Once);
            Assert.That(productTransactionResult.ProductId, Is.EqualTo(1));
        }

        [Test]
        public void CreateProductTransaction_WhenProductInStockIsLessThenProductTransactionQuantity_ShouldReturnInvalidOperationRequest()
        {
            //Arrange
            _transactionType.IsIncoming = false;

            _productTransactionRepository.Setup(s => s.Create(_productTransaction)).Returns(_productTransaction);
            var transactionTypeId = _transactionTypeRepository.Setup(s => s.GetTransactionTypeById(1)).Returns(_transactionType);

            var productInStock = _stockService.Setup(s => s.GetProductInStockById(1, 1)).Returns(new StockProductViewModel()
            {
                ProductId = 1,
                ProductName = "Coca",
                StockQuantity = 5,
                AverageCost = 10,
                StockId = 1
            });
            _productTransactionRepository.Setup(s => s.GetById(It.IsAny<int>())).Returns(_productTransaction);

            //Act
            var result = _transactionService.CreateProductTransaction(_productTransaction);

            //Assert
            Assert.That(result, Is.Not.Null);
            _productTransactionRepository.Verify(v => v.GetById(It.IsAny<int>()), Times.Never);
            
        }

    }
}
