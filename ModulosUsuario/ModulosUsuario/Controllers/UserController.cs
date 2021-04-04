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

            userService.CreateUser(new User());

            return View();
        }

        [HttpPost]

        public User CreateUser(User user)
        {
            userService.CreateUser(user);
            return user;
        }
    }
}
