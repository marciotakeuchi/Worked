using System.ComponentModel.DataAnnotations;

namespace Worked.Application.ViewModels
{
    public class CargoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(150)]
        public string Nome { get; set; }

        [MaxLength(500)]
        [Required(ErrorMessage = "Informe a descrição")]
        public string Descricao { get; set; }
    }
}
