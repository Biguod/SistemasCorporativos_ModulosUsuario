using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;

namespace ModulosUsuario.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService productService;
        private readonly IUnityTypeService unityTypeService;

        public ProductController(IProductService productService,
                                 IUnityTypeService unityTypeService)
        {
            this.productService = productService;
            this.unityTypeService = unityTypeService;
        }

        public IActionResult Index()
        {
            var products = productService.GetProducts();
            return View(products);
        }

        [HttpPost]
        public ActionResult CreateOrEdit(Product product)
        {
            if (this.ModelState.IsValid)
            {
                product = productService.CreateOrEditProduct(product);
                return RedirectToAction("Index");
            }

            ViewBag.UnityTypes = new SelectList(unityTypeService.GetUnityTypes(), "UnityTypeId", "Description");

            return View("Form", product);
        }

        public ActionResult CreateOrEdit(int productId)
        {

            var product = productService.GetProductById(productId);

            ViewBag.UnityTypes = new SelectList(unityTypeService.GetUnityTypes(), "UnityTypeId", "Description");

            return View("Form", product);
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            productService.DeleteProduct(productId);

            return RedirectToAction("Index");
        }

    }
}
