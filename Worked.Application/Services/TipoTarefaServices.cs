using AutoMapper;
using Worked.Application.Interfaces;
using Worked.Application.ViewModels;
using Worked.Domain.Interfaces;

namespace Worked.Application.Services
{
    public class TipoTarefaServices : ITipoTarefaServices
    {
        private ITipoTarefaRepository _tipoTarefaRepository;
        private readonly IMapper _mapper;
        public TipoTarefaServices(ITipoTarefaRepository tipoTarefaRepository, IMapper mapper)
        {
            _tipoTarefaRepository = tipoTarefaRepository;
            _mapper = mapper;
        }

        public async Task<TipoTarefaViewModel> ConsultarPorId(int id)
        {
            var resultado = await _tipoTarefaRepository.ConsultarPorId(id);
            return _mapper.Map<TipoTarefaViewModel>(resultado);
        }

        public async Task<ICollection<TipoTarefaViewModel>> Listar()
        {
            var resultado = await _tipoTarefaRepository.Listar();
            return _mapper.Map<ICollection<TipoTarefaViewModel>>(resultado);
        }
    }
}
