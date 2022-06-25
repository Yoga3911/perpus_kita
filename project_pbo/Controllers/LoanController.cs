using Microsoft.AspNetCore.Mvc;
using project_pbo.Models;
using System.Diagnostics;
using project_pbo.Services;

namespace project_pbo.Controllers
{
    public class LoanController : Controller
    {
        private readonly ILogger<LoanController> _logger;
        LoanService loanService = new LoanService();

        public LoanController(ILogger<LoanController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}