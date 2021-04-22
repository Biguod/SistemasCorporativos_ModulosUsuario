using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Services
{
    public class ProductService : IProductService
    {
        public readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> GetProducts()
        {
            return productRepository.GetAll();
        }

        public void DeleteProduct(int productId)
        {
            var product = productRepository.GetById(productId);
            if (product.ProductId == 0)
                return; //throw exception aqui !!!

            productRepository.Delete(product);
        }

        public Product GetProductById(int productId)
        {
            var product = productRepository.GetById(productId);
            
            return product;
        }

        public Product CreateOrEditProduct(Product product)
        {
            if(product.ProductId == 0)
            {
                return CreateProduct(product);
            }
            return UpdateProduct(product);
        }

        private Product CreateProduct(Product product)
        {
            productRepository.Create(product);
            return product;
        }

        private Product UpdateProduct(Product product)
        {
            productRepository.Update(product);
            return product;
        }
    }
}
