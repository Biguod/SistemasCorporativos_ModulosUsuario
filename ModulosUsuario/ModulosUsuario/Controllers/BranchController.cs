using Microsoft.AspNetCore.Mvc;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;

namespace ModulosUsuario.Controllers
{
    public class BranchController : Controller
    {

        private readonly IBranchService branchService;

        public BranchController(IBranchService branchService)
        {
            this.branchService = branchService;
        }

        public IActionResult Index()
        {
            var branchs = branchService.GetBranches();
            return View(branchs);
        }

        [HttpPost]
        public ActionResult CreateOrEdit(Branch branch)
        {
            if (this.ModelState.IsValid)
            {
                branch = branchService.CreateOrEditBranch(branch);
                return RedirectToAction("Index");
            }

            return View("Form", branch);
        }

        public ActionResult CreateOrEdit(int branchId)
        {

            var branch = branchService.GetBranchById(branchId);

            return View("Form", branch);
        }

        [HttpPost]
        public ActionResult Delete(int branchId)
        {
            branchService.DeleteBranch(branchId);

            return RedirectToAction("Index");
        }

    }
}
