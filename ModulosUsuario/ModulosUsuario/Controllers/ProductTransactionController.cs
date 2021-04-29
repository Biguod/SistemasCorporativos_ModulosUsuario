using Microsoft.AspNetCore.Mvc;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModulosUsuario.Controllers
{
    public class ProductTransactionController : Controller
    {

        private readonly IProductService productService;

        public ProductTransactionController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            var productTransactions = productService.GetProductTransactions();
            return View(productTransactions);
        }

        [HttpPost]
        public ActionResult Create(ProductTransaction productTransaction)
        {
            if (this.ModelState.IsValid)
            {
                productTransaction = productService.CreateProductTransaction(productTransaction);
                return RedirectToAction("Index");
            }

            return View("Form", productTransaction);
        }


    }
}
