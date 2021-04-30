using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;

namespace ModulosUsuario.Controllers
{
    public class StockController : Controller
    {

        private readonly ITransactionService transactionService;
        private readonly IStockService stockService;
        private readonly IProductService productService;
        private readonly IMaterialService materialService;
        private readonly IToolsService toolsService;

        public StockController(ITransactionService transactionService,
            IStockService stockService, 
            IProductService productService,
            IMaterialService materialService,
            IToolsService toolsService)
        {
            this.transactionService = transactionService;
            this.stockService = stockService;
            this.productService = productService;
            this.materialService = materialService;
            this.toolsService = toolsService;
        }

        public IActionResult Index()
        {
            return View(transactionService.GetTransactionsList());
        }

        public IActionResult Details(int stockId)
        {
            return View(transactionService.GetTransactionsByStock(stockId));
//            select p.ProductId,
//sum(CASE
//                WHEN tt.IsIncoming = 1 THEN pt.Quantity * pt.UnityValue
//                ELSE 0
//        END) / sum(CASE
//                WHEN tt.IsIncoming = 1 THEN pt.quantity
//                ELSE 0
//        END),
//sum(CASE
//                WHEN tt.IsIncoming = 1 THEN pt.quantity
//                ELSE 0
//        END) - sum(CASE
//                WHEN tt.IsIncoming = 0 THEN pt.quantity
//                ELSE 0
//        END),
//s.StockId
//from ProductTransaction pt
//inner join Stock s on s.StockId = pt.StockId
//inner join Product p on p.ProductId = pt.ProductId
//inner join TransactionType tt on tt.TransactionTypeId = pt.TransactionTypeId
//group by s.stockId, p.ProductId
        }
    }
}
