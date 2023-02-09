namespace Worked.Domain.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public DateTime DataTarefa { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }
        public TimeSpan TotalHoras
        {
            get { return this.TotalHoras; }
            set { this.TotalHoras = HoraTermino.Subtract(HoraInicio); }
        }
        public string Descricao { get; set; }
        public int TipoTarefaId { get; set; }
        public virtual TipoTarefa TipoTarefa { get; set; }
        public int FuncionarioId { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public DateTime DataRegistro { get; set; }
        public bool Enviado { get; set; }
        public bool Aprovado { get; set; }
        public int? GestorAprovadorId { get; set; }
    }
}
