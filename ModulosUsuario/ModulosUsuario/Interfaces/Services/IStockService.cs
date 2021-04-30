using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Services
{
    public interface IStockService
    {
        IEnumerable<Stock> GetStocks();
        Stock CreateStock(Stock stock);
        Stock GetStockById(int stockId);
    }
}
