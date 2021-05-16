using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product CreateOrEditProduct(Product product);
        void DeleteProduct(int productId);
        Product GetProductById(int productId);
        IEnumerable<ProductTransaction> GetProductTransactions();
        ProductTransaction GetByProductTransactionId(int productTransactionId);
        IEnumerable<ProductTransaction> GetTransactionsByProductId(int productId);
    }
}
