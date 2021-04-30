using ModulosUsuario.Models;
using System.Collections.Generic;

namespace ModulosUsuario.Interfaces.Repositories
{
    public interface IStockRepository
    {
        IEnumerable<Stock> GetAll();
        Stock Create(Stock stock);
        Stock GetById(int stockId);
    }
}
