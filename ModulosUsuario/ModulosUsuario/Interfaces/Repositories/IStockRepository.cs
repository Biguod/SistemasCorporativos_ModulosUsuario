using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Repositories
{
    public interface IStockRepository
    {
        IEnumerable<Stock> GetAll();
        Stock Create(Stock stock);
        Stock GetById(int stockId);
        IEnumerable<StockProductViewModel> GetProductsById(int stockId);
        IEnumerable<StockMaterialViewModel> GetMaterialsById(int stockId);
        IEnumerable<StockToolViewModel> GetToolsById(int stockId);
        StockProductViewModel GetProductInStockById(int stockId, int productId);

    }
}