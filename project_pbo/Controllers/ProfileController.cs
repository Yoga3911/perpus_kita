using Microsoft.AspNetCore.Mvc;
using project_pbo.Models;
using System.Diagnostics;
using project_pbo.Services;

namespace project_pbo.Controllers
{
    public class ProfileController : Controller
    {
        UserService userService = new UserService();
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(ILogger<ProfileController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["status"] = HttpContext.Session.GetString("statusUser");
            ViewData["id"] = HttpContext.Session.GetInt32("id");
            ViewData["data"] = userService.GetById((int)HttpContext.Session.GetInt32("id")!);
            return View();
        }

        [HttpGet]
        public IActionResult EditProfile(int userId)
        {
            ViewData["data"] = userService.GetById(userId);
            ViewData["status"] = HttpContext.Session.GetString("statusUser");
            return View();
        }

        [HttpPost]
        public IActionResult ApplyUserhanges(UserModel userModel)
        {
            ViewData["status"] = HttpContext.Session.GetString("statusUser");
            userService.UpdateUser(userModel.FirstName!, userModel.LastName!, userModel.Address!, userModel.Phone!, userModel.UserId!);

            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}