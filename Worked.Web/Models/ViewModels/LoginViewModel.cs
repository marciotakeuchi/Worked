using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Worked.Web.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [DisplayName("Permanecer Logado?")]
        public bool PermanecerLogado { get; set; }
    }
}
