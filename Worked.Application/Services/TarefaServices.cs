using AutoMapper;
using Worked.Application.Interfaces;
using Worked.Application.ViewModels;
using Worked.Domain.Entities;
using Worked.Domain.Interfaces;

namespace Worked.Application.Services
{
    public class TarefaServices : ITarefaServices
    {
        private ITarefaRepository _tarefaRepository;
        private readonly IMapper _mapper;

        public TarefaServices(ITarefaRepository tarefaRepository, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
        }

        public async Task<TarefaViewModel> ConsultarPorId(int id)
        {
            var resultado = await _tarefaRepository.ConsultarPorId(id);
            return EntityToViewModel(resultado);
        }

        public async Task<ICollection<TarefaViewModel>> Listar()
        {
            var resultado = await _tarefaRepository.Listar();
            return EntityToViewModel(resultado);
        }

        public void Inserir(TarefaViewModel tarefa)
        {
            _tarefaRepository.Inserir(ViewModelToEntity(tarefa));
        }


        public void Alterar(TarefaViewModel tarefa)
        {
            _tarefaRepository.Alterar(ViewModelToEntity(tarefa));

        }
        public void Excluir(int id)
        {
            var tarefa = _tarefaRepository.ConsultarPorId(id).Result;
            _tarefaRepository.Excluir(tarefa);
        }


        private Tarefa ViewModelToEntity(TarefaViewModel tarefa)
        {
            return _mapper.Map<Tarefa>(tarefa);
        }

        private TarefaViewModel EntityToViewModel(Tarefa resultado)
        {
            return _mapper.Map<TarefaViewModel>(resultado);
        }

        private ICollection<TarefaViewModel> EntityToViewModel(ICollection<Tarefa> resultado)
        {
            return _mapper.Map<ICollection<TarefaViewModel>>(resultado);
        }
    }
}
