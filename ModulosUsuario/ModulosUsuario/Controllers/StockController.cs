using Microsoft.AspNetCore.Mvc;
using ModulosUsuario.Interfaces.Services;

namespace ModulosUsuario.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockService stockService;

        public StockController(IStockService stockService)
        {
            this.stockService = stockService;
        }

        public IActionResult Index()
        {
            return View(stockService.GetStockList());
        }

        public IActionResult Details(int stockId)
        {
            return View(stockService.GetStockDetails(stockId));
        }
    }
}