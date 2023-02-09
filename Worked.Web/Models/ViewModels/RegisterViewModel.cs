using System.ComponentModel.DataAnnotations;
using Worked.Domain.Entities;

namespace Worked.Web.Models.ViewModels
{
    public class RegisterViewModel : Funcionario
    {


        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter no mínimo {2} e máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Senha", ErrorMessage = "A senha e a confirmação de senha devem ser iguais.")]
        public string ConfirmarSenha { get; set; }

        public ICollection<Cargo> Cargos { get; set; }
        public ICollection<Funcionario> Gestores { get; set; }
        public ICollection<RegimeTrabalhista> RegimesTrabalhistas { get; set; }

    }
}
