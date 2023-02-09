using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Worked.Domain.Entities;

namespace Worked.Application.ViewModels
{
    public class TarefaViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [DisplayName("Data da Tarefa")]
        public DateTime DataTarefa { get; set; }

        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Informe o horário de início da tarefa")]
        [DisplayName("Início da tarefa")]
        public TimeSpan HoraInicio { get; set; }

        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Informe o horário de término da tarefa")]
        [DisplayName("Término da tarefa")]
        public TimeSpan HoraTermino { get; set; }

        [DisplayName("Total de horas da atividade")]
        public TimeSpan TotalHoras
        {
            get { return this.TotalHoras; }
            set { this.TotalHoras = HoraTermino.Subtract(HoraInicio); }
        }

        [Required(ErrorMessage = "Informe a descrição da atividade realizada")]
        [MaxLength(2000)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        public virtual TipoTarefa TipoTarefa { get; set; }

        public virtual Funcionario Funcionario { get; set; }


        [DisplayName("Data Registro Tarefa")]
        public DateTime DataRegistro { get; set; }

        [DisplayName("Enviado")]
        public bool Enviado { get; set; }
        [DisplayName("Aprovado")]
        public bool Aprovado { get; set; }
        public int? GestorAprovadorId { get; set; }


    }
}
