using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product Create(Product product);

        Product Update(Product product);

        Product GetById(int productId);

        void Delete(Product product);
    }
}
