using Microsoft.EntityFrameworkCore;
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
            return context.Product.Include(i => i.UnityType).ToList(); 
        }

        public Product Update(Product product)
        {
            context.Update(product);
            context.SaveChanges();
            return product;
        }

        public void Delete(Product product)
        {
            product.Active = false;
            context.Update(product);
            context.SaveChanges();
        }

        public Product GetById(int productId)
        {            
            return context.Product.Find(productId);
        }
    }
}
