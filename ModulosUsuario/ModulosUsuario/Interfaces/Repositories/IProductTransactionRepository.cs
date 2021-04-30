using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Repositories
{
    public interface IProductTransactionRepository
    {
        IEnumerable<ProductTransaction> GetAll();

        ProductTransaction Create(ProductTransaction productTransaction);

        IEnumerable<ProductTransaction> GetByProductId(int productId);

        ProductTransaction GetById(int productTransactionId);

        IEnumerable<ProductTransaction> GetByStockId(int stockId);

    }
}