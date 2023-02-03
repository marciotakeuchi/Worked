using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worked.Domain.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public DateTime DataTarefa { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }
        public TimeSpan TotalHoras { 
            get { return this.TotalHoras; } 
            set { this.TotalHoras = HoraTermino - HoraInicio; } 
        }
        public string Descricao { get; set; }
        public TipoTarefa TipoTarefa { get; set; }
        public Funcionario Funcionario { get; set; }
        public DateTime DataRegistro { get; set; }
        public bool Enviado { get; set; }
        public bool Aprovado { get; set; }
        public Funcionario? GestorAprovador { get; set; }
    }
}
