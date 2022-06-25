using Microsoft.AspNetCore.Mvc;
using project_pbo.Models;
using project_pbo.Services;
using System.Diagnostics;

namespace project_pbo.Controllers
{
    public class AuthController : Controller
    {
        UserService userService = new UserService();

        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public dynamic Login(string email, string password)
        {
            UserModel user = userService.LoginEmailPassword(email, password);

            if (user.Email == email && email != null)
            {
                HttpContext.Session.SetInt32("id", user.UserId);
                if (user.IsAdmin! == true)
                {
                    HttpContext.Session.SetString("statusUser", "admin");

                }
                else
                {
                    HttpContext.Session.SetString("statusUser", "user");

                }
                return user;
            }
            return false;
        }

        [HttpPost]
        public bool Register(string firstName, string lastName, string email, string password, string address, string phone)
        {
            bool success = userService.RegisterUser(firstName, lastName, email, password, address, phone);
            Console.WriteLine(success);
            if (success)
            {

                return true;
            }

            Console.WriteLine(success);
            return false;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}