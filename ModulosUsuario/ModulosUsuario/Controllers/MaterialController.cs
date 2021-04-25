using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;

namespace ModulosUsuario.Controllers
{
    public class MaterialController : Controller
    {

        private readonly IMaterialService materialService;
        private readonly IUnityTypeService unityTypeService;

        public MaterialController(IMaterialService materialService,
                                 IUnityTypeService unityTypeService)
        {
            this.materialService = materialService;
            this.unityTypeService = unityTypeService;
        }

        public IActionResult Index()
        {
            var materials = materialService.GetMaterials();
            return View(materials);
        }

        [HttpPost]
        public ActionResult CreateOrEdit(Material material)
        {
            if (this.ModelState.IsValid)
            {
                material = materialService.CreateOrEditMaterial(material);
                return RedirectToAction("Index");
            }

            ViewBag.UnityTypes = new SelectList(unityTypeService.GetUnityTypes(), "UnityTypeId", "Description");

            return View("Form", material);
        }

        public ActionResult CreateOrEdit(int materialId)
        {

            var material = materialService.GetMaterialById(materialId);

            ViewBag.UnityTypes = new SelectList(unityTypeService.GetUnityTypes(), "UnityTypeId", "Description");

            return View("Form", material);
        }

        [HttpPost]
        public ActionResult Delete(int materialId)
        {
            materialService.DeleteMaterial(materialId);

            return RedirectToAction("Index");
        }

    }
}
