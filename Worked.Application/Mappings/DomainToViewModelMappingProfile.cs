using AutoMapper;
using Worked.Application.ViewModels;
using Worked.Domain.Entities;

namespace Worked.Application.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Funcionario, FuncionarioViewModel>();
            CreateMap<Tarefa, TarefaViewModel>();
            CreateMap<Cargo, CargoViewModel>();
            CreateMap<RegimeTrabalhista, RegimeTrabalhistaViewModel>();
            CreateMap<TipoTarefa, TipoTarefaViewModel>();
        }
    }
}
