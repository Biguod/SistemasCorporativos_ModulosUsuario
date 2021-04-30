using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModulosUsuario.Services
{
    public class StockService : IStockService
    {
        public readonly IStockRepository stockRepository;
        public readonly IProductTransactionRepository productTransactionRepository;
        public readonly IMaterialTransactionRepository materialTransactionRepository;
        public readonly IToolsTransactionRepository toolsTransactionRepository;
        public readonly ITransactionTypeRepository transactionTypeRepository;

        public StockService(IStockRepository stockRepository,
            IProductTransactionRepository productTransactionRepository,
            IMaterialTransactionRepository materialTransactionRepository,
            IToolsTransactionRepository toolsTransactionRepository,
            ITransactionTypeRepository transactionTypeRepository)
        {
            this.stockRepository = stockRepository;
            this.productTransactionRepository = productTransactionRepository;
            this.materialTransactionRepository = materialTransactionRepository;
            this.toolsTransactionRepository = toolsTransactionRepository;
            this.transactionTypeRepository = transactionTypeRepository;
        }

        public IEnumerable<Stock> GetStocks()
        {
            return stockRepository.GetAll();
        }

        public Stock GetStockById(int stockId)
        {
            var stock = stockRepository.GetById(stockId);
            
            return stock;
        }

        public Stock CreateStock(Stock stock)
        {
            if(stock.StockId == 0)
            {
                return stockRepository.Create(stock); ;
            }
            return stock; //exception!!!
        }

        public IEnumerable<StockListViewModel> GetTransactionsList() //revisar
        {
            return stockRepository.GetAll().Select(s => new StockListViewModel
            {
                Stock = s
            });
        }

        public StocksViewModel GetStockDetails(int stockId)
        {
            return new StocksViewModel();
            //{
            //    Stock = stockRepository.GetById(stockId),
            //    StockProducts = productTransactionRepository.GetByStockId(stockId).ToList(),
            //    StockMaterials = materialTransactionRepository.GetByStockId(stockId).ToList(),
            //    StockTools = toolsTransactionRepository.GetByStockId(stockId).ToList(),
            //};
        }
    }
}
