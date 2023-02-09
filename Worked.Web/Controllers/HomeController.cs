using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Worked.Infra.Models;
using Worked.Web.Models;
using Worked.Web.Models.ViewModels;

namespace Worked.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Senha, model.PermanecerLogado, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    _logger.LogInformation($"Usuario {model.Email} conectou em {DateTime.Now}");


                    //   var listUsersAdmin = await _userManager.GetUsersInRoleAsync("admin");

                    //if (listUsersAdmin.FirstOrDefault(x => x.UserName == model.Email))
                    ////ViewData["UserRoleLogged"] =

                    if (!string.IsNullOrEmpty(returnUrl))
                        return LocalRedirect(returnUrl);

                    else
                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Tentativa de Login inválido");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}