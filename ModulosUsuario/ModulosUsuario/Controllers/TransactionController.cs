using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;

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
                return RedirectToAction("Details", new { stockId = materialTransaction.StockId });
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
                return RedirectToAction("Details", new { stockId = toolTransaction.StockId });
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

        public ActionResult DownloadDocumentProduct(int productTransactionId)
        {
            var productTransaction = transactionService.GetProductTransaction(productTransactionId);
            var text = "IMPRESSÃO DO DOCUMENTO FISCAL\n" + "Nome da filial: " + productTransaction.Stock.Branch.Description + 
                "\nProduto: " + productTransaction.Product.Name + 
                "\nQuantidade: " + productTransaction.Quantity + 
                "\nValor unitário: " + productTransaction.UnityValue + 
                "\nValor total: " + (productTransaction.Quantity * productTransaction.UnityValue) + 
                "\n\n\nTipo da transação: " + productTransaction.TransactionType.Description;
            return CreateDocument(text);
        }
        public ActionResult DownloadDocumentTools(int toolsTransactionId)
        {
            var toolsTransaction = transactionService.GetToolTransaction(toolsTransactionId);
            var text = "IMPRESSÃO DO DOCUMENTO FISCAL\n" + "Nome da filial: " + toolsTransaction.Stock.Branch.Description +
                            "\nFerramenta: " + toolsTransaction.Tool.Name +
                            "\nQuantidade: " + toolsTransaction.Quantity +
                            "\nValor unitário: " + toolsTransaction.UnityValue +
                            "\nValor total: " + (toolsTransaction.Quantity * toolsTransaction.UnityValue) +
                            "\n\n\nTipo da transação: " + toolsTransaction.TransactionType.Description;
            return CreateDocument(text);
        }

        public ActionResult DownloadDocumentMaterial(int materialTransactionId)
        {
            var materialTransaction = transactionService.GetMaterialTransaction(materialTransactionId);
            var text = "IMPRESSÃO DO DOCUMENTO FISCAL\n" + "Nome da filial: " + materialTransaction.Stock.Branch.Description +
                            "\nMaterial: " + materialTransaction.Material.Name +
                            "\nQuantidade: " + materialTransaction.Quantity +
                            "\nValor unitário: " + materialTransaction.UnityValue +
                            "\nValor total: " + (materialTransaction.Quantity * materialTransaction.UnityValue) +
                            "\n\n\nTipo da transação: " + materialTransaction.TransactionType.Description;
            return CreateDocument(text);
        }
        private FileStreamResult CreateDocument(string text)
        {
            //Create a new PDF document
            PdfDocument document = new PdfDocument();

            //Add a page to the document
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;

            //Set the standard font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

            //Draw the text
            graphics.DrawString(text, font, PdfBrushes.Black, new PointF(0, 0));

            //Saving the PDF to the MemoryStream
            MemoryStream stream = new MemoryStream();

            document.Save(stream);

            //Set the position as '0'.
            stream.Position = 0;

            //Download the PDF document in the browser
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");

            fileStreamResult.FileDownloadName = "DocumentoFiscal.pdf";

            return fileStreamResult;
        }
        
    }
}
