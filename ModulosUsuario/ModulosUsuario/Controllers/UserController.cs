using Microsoft.AspNetCore.Mvc;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModulosUsuario.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("CreateOrEdit", new User());
        }

        [HttpPost]

        public ActionResult CreateOrEdit(User user)
        {
            if (this.ModelState.IsValid)
            {
                user = userService.CreateUser(user);
                return RedirectToAction("Index");
            }

            return View("Form", user);
            
        }
        
        public ActionResult CreateOrEdit(int id)
        {
            var user = new User(); //pegar do banco
            return View("Form", user);
        }
    }
}
