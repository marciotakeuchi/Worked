using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Worked.Domain.Entities;

namespace Worked.Application.ViewModels
{
    public class FuncionarioViewModel
    {
        public int Id { get; set; }

        [MaxLength(250)]
        [MinLength(3)]
        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; }

        [MaxLength(11)]
        [Required(ErrorMessage = "O CPF é obrIgatório")]
        [DisplayName("CPF")]
        [DisplayFormat(DataFormatString = "{0:000\\.000\\.000-00}", ApplyFormatInEditMode = true)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento é obrigatório")]
        [DataType(DataType.Date)]
        [DisplayName("Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [MaxLength(20)]
        public string Telefone { get; set; }
        public virtual Funcionario? Gestor { get; set; }
        public virtual RegimeTrabalhista RegimeTrabalhista { get; set; }
        public virtual Cargo Cargo { get; set; }
        public virtual ICollection<Tarefa> Tarefas { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
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

        [DisplayName("Gestor")]
        public int? GestorId { get; set; }

        [DisplayName("Regime Trabalhista")]
        public int RegimeTrabalhistaId { get; set; }

        [DisplayName("Cargo")]
        public int CargoId { get; set; }
        public Guid ApplicationUserId { get; set; }
        public virtual ICollection<FuncionarioViewModel> ListaGestores { get; set; }
        public virtual ICollection<CargoViewModel> ListaCargos { get; set; }
        public virtual ICollection<RegimeTrabalhistaViewModel> ListaRegimesTrabalhistas { get; set; }
        

    }
}
