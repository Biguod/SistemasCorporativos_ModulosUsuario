using ModulosUsuario.Contexts;
using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModulosUsuario.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext context;
        public ProductRepository(DatabaseContext context) 
        {
            this.context = context;
        }

        public Product Create(Product product)
        {
            context.Add(product);
            context.SaveChanges();
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Product.ToList(); 
        }

        public Product Update(Product product)
        {
            context.Update(product);
            context.SaveChanges();
            return product;
        }

        public void Delete(Product product)
        {
            context.Remove(product);
            context.SaveChanges();
        }

        public Product GetById(int productId)
        {
            var product = context.Product.Find(productId);
            if(product == null)
                product = new Product();
            return product;
        }
    }
}
