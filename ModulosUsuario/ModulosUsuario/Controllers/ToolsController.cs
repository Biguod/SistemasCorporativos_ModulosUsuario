using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;

namespace ModulosUsuario.Controllers
{
    public class ToolsController : Controller
    {

        private readonly IToolsService toolsService;
        private readonly IUnityTypeService unityTypeService;

        public ToolsController(IToolsService toolsService,
                                 IUnityTypeService unityTypeService)
        {
            this.toolsService = toolsService;
            this.unityTypeService = unityTypeService;
        }

        public IActionResult Index()
        {
            var toolss = toolsService.GetTools();
            return View(toolss);
        }

        [HttpPost]
        public ActionResult CreateOrEdit(Tools tools)
        {
            if (this.ModelState.IsValid)
            {
                tools = toolsService.CreateOrEditTools(tools);
                return RedirectToAction("Index");
            }

            ViewBag.UnityTypes = new SelectList(unityTypeService.GetUnityTypes(), "UnityTypeId", "Description");

            return View("Form", tools);
        }

        public ActionResult CreateOrEdit(int toolsId)
        {

            var tools = toolsService.GetToolsById(toolsId);

            ViewBag.UnityTypes = new SelectList(unityTypeService.GetUnityTypes(), "UnityTypeId", "Description");

            return View("Form", tools);
        }

        [HttpPost]
        public ActionResult Delete(int toolsId)
        {
            toolsService.DeleteTools(toolsId);

            return RedirectToAction("Index");
        }

        public ActionResult Logs(int toolsId)
        {
            return View(new Tools {ToolsId = 0});
        }

    }
}
