using System.Diagnostics;
using manita_dotnet_assignment.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace manita_dotnet_assignment.Controllers
{
    [Authorize(Roles = "Admin")] // Restrict this controller to Admin only
    public class PrivacyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")] // Restrict Privacy page to Admin users
        public IActionResult Privacy()
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
