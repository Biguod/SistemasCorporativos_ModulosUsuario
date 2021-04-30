using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;

namespace ModulosUsuario.Controllers
{
    public class TransactionController : Controller
    {

        private readonly ITransactionService transactionService;
        private readonly IStockService stockService;
        private readonly IProductService productService;
        private readonly IMaterialService materialService;
        private readonly IToolsService toolsService;

        public TransactionController(ITransactionService transactionService,
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
        }

        [HttpPost]
        public ActionResult CreateProductTransaction(ProductTransaction productTransaction)
        {
            if (this.ModelState.IsValid)
            {
                productTransaction = transactionService.CreateProductTransaction(productTransaction);
                return RedirectToAction("Details", new { stockId = productTransaction.StockId });
            }

            ViewBag.TransactionTypes = new SelectList(transactionService.GetTransactionTypeList(), "TransactionTypeId", "Description");
            ViewBag.Products = new SelectList(productService.GetProducts(), "ProductId", "Name");

            return View("ProductTransactionForm", productTransaction);
        }

        public ActionResult CreateProductTransaction(int stockId)
        {
            var productTransaction = new ProductTransaction { StockId = stockId };

            ViewBag.TransactionTypes = new SelectList(transactionService.GetTransactionTypeList(), "TransactionTypeId", "Description");
            ViewBag.Products = new SelectList(productService.GetProducts(), "ProductId", "Name");

            return View("ProductTransactionForm", productTransaction);
        }

        [HttpPost]
        public ActionResult CreateMaterialTransaction(MaterialTransaction materialTransaction)
        {
            if (this.ModelState.IsValid)
            {
                materialTransaction = transactionService.CreateMaterialTransaction(materialTransaction);
                return RedirectToAction("Details", materialTransaction.StockId);
            }

            ViewBag.TransactionTypes = new SelectList(transactionService.GetTransactionTypeList(), "TransactionTypeId", "Description");
            ViewBag.Materials = new SelectList(materialService.GetMaterials(), "MaterialId", "Name");

            return View("MaterialTransactionForm", materialTransaction);
        }

        public ActionResult CreateMaterialTransaction(int stockId)
        {
            var materialTransaction = new MaterialTransaction { StockId = stockId };

            ViewBag.TransactionTypes = new SelectList(transactionService.GetTransactionTypeList(), "TransactionTypeId", "Description");
            ViewBag.Materials = new SelectList(materialService.GetMaterials(), "MaterialId", "Name");

            return View("MaterialTransactionForm", materialTransaction);
        }


        [HttpPost]
        public ActionResult CreateToolTransaction(ToolsTransaction toolTransaction)
        {
            if (this.ModelState.IsValid)
            {
                toolTransaction = transactionService.CreateToolTransaction(toolTransaction);
                return RedirectToAction("Details", toolTransaction.StockId);
            }

            ViewBag.TransactionTypes = new SelectList(transactionService.GetTransactionTypeList(), "TransactionTypeId", "Description");
            ViewBag.Tools = new SelectList(toolsService.GetTools(), "ToolsId", "Name");

            return View("ToolTransactionForm", toolTransaction);
        }

        public ActionResult CreateToolTransaction(int stockId)
        {
            var toolTransaction = new ToolsTransaction { StockId = stockId };

            ViewBag.TransactionTypes = new SelectList(transactionService.GetTransactionTypeList(), "TransactionTypeId", "Description");
            ViewBag.Tools = new SelectList(toolsService.GetTools(), "ToolsId", "Name");

            return View("ToolTransactionForm", toolTransaction);
        }
    }
}
