using AutoMapper;
using Worked.Application.ViewModels;
using Worked.Domain.Entities;

namespace Worked.Application.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<FuncionarioViewModel, Funcionario>();
            CreateMap<TarefaViewModel, Tarefa>();
            CreateMap<CargoViewModel, Cargo>();
            CreateMap<RegimeTrabalhistaViewModel, RegimeTrabalhista>();
            CreateMap<TipoTarefaViewModel, TipoTarefa>();
        }
    }
}
