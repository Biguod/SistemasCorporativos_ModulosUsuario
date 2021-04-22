using Microsoft.AspNetCore.Mvc;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Models;
using System.Collections.Generic;

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
            var users = userService.GetUsers();
            return View(users);
        }

        [HttpPost]
        public ActionResult CreateOrEdit(User user)
        {
            if (this.ModelState.IsValid)
            {
                user = userService.CreateOrEditUser(user);
                return RedirectToAction("Index");
            }

            return View("Form", user);
        }
        
        public ActionResult CreateOrEdit(int userId)
        {
            var user = userService.GetUserById(userId);

            return View("Form", user);
        }

        [HttpPost]
        public ActionResult Delete(int userId)
        {
            userService.DeleteUser(userId);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult GetNewAddress(User user)
        {
            if (user.Addresses == null)
                user.Addresses = new List<AddressUser>();

            user.Addresses.Add(new AddressUser());

            return View("Form", user);
        }

    }
}
