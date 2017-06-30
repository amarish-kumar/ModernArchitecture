using System;
using MA.DomainEntities;
using MA.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace MA.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            _userService.InsertUser(new User{ID = Guid.NewGuid(), IsActive = true, Username = "Hello"});

            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View(_userService.GetUsers(false));
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
