using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Worked.Application.Interfaces;
using Worked.Application.ViewModels;
using Worked.Domain.Entities;
using Worked.Infra.Models;

namespace Worked.Web.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFuncionarioServices _funcionarioServices;
        private readonly ICargoServices _cargoServices;
        private readonly IRegimeTrabalhistaServices _regimeTrabalhistaServices;


        public UserAccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IFuncionarioServices funcionarioServices, ICargoServices cargoServices, IRegimeTrabalhistaServices regimeTrabalhistaServices)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _funcionarioServices = funcionarioServices;
            _cargoServices = cargoServices;
            _regimeTrabalhistaServices = regimeTrabalhistaServices;
        }

        [HttpGet]
        public IActionResult Index()
        {

            if (TempData.TryGetValue("SuccessMessage", out object? value))
            {
                ViewData["SuccessMessage"] = value;
            }

            ICollection<ApplicationUser> userAccounts = _userManager.Users.Include(x => x.Funcionario).ToList();
            return View(userAccounts);

        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Register()
        {
            var funcionarioViewModel = new FuncionarioViewModel();
            await LoadFuncionarioListasComplementares(funcionarioViewModel);

            return View(funcionarioViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(FuncionarioViewModel model)
        {
            ModelState.Remove("Cargo");
            ModelState.Remove("RegimeTrabalhista");
            ModelState.Remove("Gestor");
            ModelState.Remove("ListaCargos");
            ModelState.Remove("ListaRegimesTrabalhistas");
            ModelState.Remove("ListaGestores");
            ModelState.Remove("Tarefas");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Senha);

                if (result.Succeeded)
                {

                    if (model.GestorId == 0) model.GestorId = null;


                    var funcionarioInserido = _funcionarioServices.Inserir(model);

                    if (funcionarioInserido.Id != 0)
                    {
                        user.FuncionarioId = funcionarioInserido.Id;
                        await _userManager.UpdateAsync(user);
                    }

                    TempData["SuccessMessage"] = $"Usuário {funcionarioInserido.Nome} cadastrado com sucesso!";

                    return RedirectToAction("Index", "UserAccount");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            await LoadFuncionarioListasComplementares(model);
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Detalhar(int id)
        {
            FuncionarioViewModel funcionarioViewModel = await _funcionarioServices.ConsultarPorId(id);
            await LoadFuncionarioListasComplementares(funcionarioViewModel);
            return View(funcionarioViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            FuncionarioViewModel funcionarioViewModel = await _funcionarioServices.ConsultarPorId(id);
            await LoadFuncionarioListasComplementares(funcionarioViewModel);
            return View(funcionarioViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(FuncionarioViewModel model)
        {
            ModelState.Remove("Cargo");
            ModelState.Remove("RegimeTrabalhista");
            ModelState.Remove("Gestor");
            ModelState.Remove("ListaCargos");
            ModelState.Remove("ListaRegimesTrabalhistas");
            ModelState.Remove("ListaGestores");
            ModelState.Remove("Tarefas");
            if (ModelState.IsValid)
            {
                if (model.GestorId == 0) model.GestorId = null;

                _funcionarioServices.Alterar(model);

                TempData["SuccessMessage"] = $"Usuário {model.Nome} alterado com sucesso!";

                return RedirectToAction("Index", "UserAccount");
            }

            await LoadFuncionarioListasComplementares(model);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> Excluir(string id)
        {
            var applicationUser = await _userManager.Users.Include(x => x.Funcionario).FirstOrDefaultAsync(x => x.Id.ToString() == id);

            if (applicationUser is null)
            {
                throw new ApplicationException("Usuario nao encontrado.");
            }

            int funcionarioID = applicationUser.FuncionarioId ?? default(int);
            string funcionarioNome = applicationUser.Funcionario.Nome;

            await _userManager.DeleteAsync(applicationUser);
            _funcionarioServices.Excluir(funcionarioID);

            TempData["SuccessMessage"] = $"Usuário {funcionarioNome} excluído com sucesso!";

            return RedirectToAction("Index", "UserAccount");
        }

        private FuncionarioViewModel EntityToViewModel(Funcionario funcionario)
        {
            FuncionarioViewModel funcionarioViewModel = new FuncionarioViewModel();
            funcionarioViewModel.Id = funcionario.Id;
            funcionarioViewModel.Nome = funcionario.Nome;
            funcionarioViewModel.Cpf = funcionario.Cpf;
            funcionarioViewModel.DataNascimento = funcionario.DataNascimento;
            funcionarioViewModel.Email = funcionario.Email;
            funcionarioViewModel.Telefone = funcionario.Telefone;
            funcionarioViewModel.GestorId = funcionario.GestorId;
            funcionarioViewModel.RegimeTrabalhistaId = funcionario.RegimeTrabalhistaId;
            funcionarioViewModel.CargoId = funcionario.CargoId;

            return funcionarioViewModel;
        }

        private async Task LoadFuncionarioListasComplementares(FuncionarioViewModel funcionarioViewModel)
        {
            funcionarioViewModel.ListaGestores = await _funcionarioServices.Listar();
            funcionarioViewModel.ListaCargos = await _cargoServices.Listar();
            funcionarioViewModel.ListaRegimesTrabalhistas = await _regimeTrabalhistaServices.Listar();

            funcionarioViewModel.ListaGestores.Add(new FuncionarioViewModel { Id = 0, Nome = "Selecione" });
            funcionarioViewModel.ListaCargos.Add(new CargoViewModel { Id = 0, Nome = "Selecione" });
            funcionarioViewModel.ListaRegimesTrabalhistas.Add(new RegimeTrabalhistaViewModel { Id = 0, Descricao = "Selecione" });

            funcionarioViewModel.ListaGestores = funcionarioViewModel.ListaGestores.OrderBy(x => x.Id).ToList();
            funcionarioViewModel.ListaCargos = funcionarioViewModel.ListaCargos.OrderBy(x => x.Id).ToList();
            funcionarioViewModel.ListaRegimesTrabalhistas = funcionarioViewModel.ListaRegimesTrabalhistas.OrderBy(x => x.Id).ToList();
        }
    }
}
