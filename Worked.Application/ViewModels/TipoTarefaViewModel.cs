using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Worked.Application.ViewModels
{
    public class TipoTarefaViewModel
    {
        public int Id { get; set; }

        [MaxLength(500)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
