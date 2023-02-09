using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Worked.Infra.Models;

namespace Worked.Infra.Controllers
{
    public class HomeInfraController : Controller
    {
        private readonly ILogger<HomeInfraController> _logger;

        public HomeInfraController(ILogger<HomeInfraController> logger)
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
            return View(new InfraErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}