using System.ComponentModel.DataAnnotations;

namespace Worked.Application.ViewModels
{
    public class RegimeTrabalhistaViewModel
    {
        public int Id { get; set; }

        [MaxLength(500)]
        [Required(ErrorMessage = "Informe a descrição")]
        public string Descricao { get; set; }
    }
}
