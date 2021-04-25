using Microsoft.AspNetCore.Mvc;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;

namespace ModulosUsuario.Controllers
{
    public class UnityTypeController : Controller
    {

        private readonly IUnityTypeService unityTypeService;

        public UnityTypeController(IUnityTypeService unityTypeService)
        {
            this.unityTypeService = unityTypeService;
        }

        public IActionResult Index()
        {
            var unityTypes = unityTypeService.GetUnityTypes();
            return View(unityTypes);
        }

        [HttpPost]
        public ActionResult CreateOrEdit(UnityType unityType)
        {
            if (this.ModelState.IsValid)
            {
                unityType = unityTypeService.CreateOrEditUnityType(unityType);
                return RedirectToAction("Index");
            }

            return View("Form", unityType);
        }

        public ActionResult CreateOrEdit(int unityTypeId)
        {

            var unityType = unityTypeService.GetUnityTypeById(unityTypeId);

            return View("Form", unityType);
        }

        [HttpPost]
        public ActionResult Delete(int unityTypeId)
        {
            unityTypeService.DeleteUnityType(unityTypeId);

            return RedirectToAction("Index");
        }

    }
}
