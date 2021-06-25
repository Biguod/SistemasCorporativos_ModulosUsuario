using Microsoft.AspNetCore.Mvc;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;

namespace ModulosUsuario.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleService saleService;

        public SaleController(ISaleService saleService)
        {
            this.saleService = saleService;
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

        public IActionResult ShopCartIndex()
        {
            try
            {
                return View("~/Views/Sale/ShopCart/Index.cshtml", saleService.GetCartByCustomer(1)); //mudar aqui qnd ter o .User
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}