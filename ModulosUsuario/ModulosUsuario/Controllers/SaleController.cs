using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Collections.Generic;
using Syncfusion.Drawing;
using System.IO;
using System.Linq;

namespace ModulosUsuario.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleService saleService;
        private readonly IUserService userService;
        private readonly IPaymentService paymentService;
        private readonly ITransactionService transactionService;

        public SaleController(ISaleService saleService,
            IUserService userService,
            IPaymentService paymentService,
            ITransactionService transactionService)
        {
            this.saleService = saleService;
            this.userService = userService;
            this.paymentService = paymentService;
            this.transactionService = transactionService;
        }

        public IActionResult Index()
        {
            return View(saleService.GetAllProducts());
        }

        public IActionResult Details(int productId, int stockId)
        {
            return View(saleService.GetProductForSaleById(stockId, productId));
        }

        public IActionResult ReserveProduct(SaleViewModel model)
        {
            try
            {

                saleService.ReserveProduct(model);
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult CancelProductReserved(int productTransactionId)
        {
            try
            {
                saleService.CancelReservedSale(productTransactionId);
                return RedirectToAction("ShopCartIndex");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IActionResult ShopCartIndex(ShopCartViewModel cart)
        {
            try
            {
                var userId = 1;
                var user = userService.GetUserById(userId); //mudar aqui qnd ter o user 

                if(cart == null || cart.Products == null || cart.Products.Count == 0)
                    cart = saleService.GetCartByCustomer(user);

                if(cart == null || cart.Products == null || cart.Products.Count == 0)
                    return RedirectToAction("Index");

                ViewBag.UserAdresses = new SelectList(user.Addresses, "AddressId", "PostalCode");
                ViewBag.PaymentMethods = new SelectList(paymentService.GetPaymentMethods(), "PaymentMethodId", "Description");

                return View("~/Views/Sale/ShopCart/Index.cshtml", cart);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult FinishSale(ShopCartViewModel model)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    var sales = saleService.FinishSale(model);
                    var text = GenerateDocumentSaleTemplate(sales);
                    return CreateDocument(text);
                }
                return RedirectToAction("ShopCartIndex", model);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private string GenerateDocumentSaleTemplate(List<Sale> sales)
        {
            var productTransactionSold = transactionService.GetProductTransaction(sales.First().ProductTransactionId);
            var customer = userService.GetUserById(productTransactionSold.UserId);
            var customerAddress = customer.Addresses.Where(w => w.AddressId == sales.First().DeliveryAddressUserId).FirstOrDefault();
            var paymentMethod = sales.First().PaymentMethod.Description;
            var totalPrice = sales.First().TotalPrice;

            var text = "IMPRESSÃO DO DOCUMENTO FISCAL\n" + "\nNome da filial: " + productTransactionSold.Stock.Branch.Description +
                "\n\nCliente: " + customer.Name + " " + customer.LastName +
                "\nEndereço de entrega:\nRua: " + customerAddress.Street + "\nNumero: " + customerAddress.Number + "\nCEP:  " + customerAddress.PostalCode + "\nCidade: " + customerAddress.City + "\nEstado: " + customerAddress.State + "\nBairro: " + customerAddress.District +
                "\n\nMétodo de pagamento: " + paymentMethod;

                ;

            foreach (var sale in sales)
            {
                if(productTransactionSold == null)
                {
                    productTransactionSold = transactionService.GetProductTransaction(sale.ProductTransactionId);
                    totalPrice += sale.TotalPrice;
                }

                text += "\n\nProduto: " + productTransactionSold.Product.Name +
                "\nQuantidade: " + productTransactionSold.Quantity +
                "\nValor unitário: " + productTransactionSold.UnityValue +
                "\nValor total: " + (productTransactionSold.Quantity * productTransactionSold.UnityValue);

                
                productTransactionSold = null;
            }

            text += "\n\n Valor Total da Compra: " + totalPrice;

            return text;
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