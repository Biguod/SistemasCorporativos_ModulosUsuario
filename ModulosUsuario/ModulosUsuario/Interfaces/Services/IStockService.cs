using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Services
{
    public interface IStockService
    {
        IEnumerable<Stock> GetStocks();
        Stock CreateStock(Stock stock);
        Stock GetStockById(int stockId);
        IEnumerable<StockListViewModel> GetStockList();
        StocksViewModel GetStockDetails(int stockId);
        StockProductViewModel GetProductInStockById(int stockId, int productId);
        StockMaterialViewModel GetMaterialInStockById(int stockId, int materialId);
    }
}