using AutoMapper;
using Worked.Application.Interfaces;
using Worked.Application.ViewModels;
using Worked.Domain.Entities;
using Worked.Domain.Interfaces;

namespace Worked.Application.Services
{
    public class FuncionarioServices : IFuncionarioServices
    {
        private IFuncionarioRepository _funcionarioRepository;
        private readonly IMapper _mapper;

        public FuncionarioServices(IFuncionarioRepository funcionarioRepository, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }

        public async Task<FuncionarioViewModel> ConsultarPorId(int id)
        {
            var resultado = await _funcionarioRepository.ConsultarPorId(id);
            return EntityToViewModel(resultado);
        }

        public async Task<ICollection<FuncionarioViewModel>> Listar()
        {
            var resultado = await _funcionarioRepository.Listar();
            return EntityToViewModel(resultado);
        }

        public FuncionarioViewModel Inserir(FuncionarioViewModel funcionario)
        {
            Funcionario funcionarioInserido = _funcionarioRepository.Inserir(ViewModelToEntity(funcionario));
            return EntityToViewModel(funcionarioInserido);
        }

        public void Alterar(FuncionarioViewModel funcionario)
        {
            _funcionarioRepository.Alterar(ViewModelToEntity(funcionario));
        }

        public void Excluir(int id)
        {
            var funcionario = _funcionarioRepository.ConsultarPorId(id).Result;
            _funcionarioRepository.Excluir(funcionario);
        }


        private Funcionario ViewModelToEntity(FuncionarioViewModel funcionario)
        {
            return _mapper.Map<Funcionario>(funcionario);
        }

        private FuncionarioViewModel EntityToViewModel(Funcionario funcionario)
        {
            return _mapper.Map<FuncionarioViewModel>(funcionario);
        }

        private ICollection<FuncionarioViewModel> EntityToViewModel(ICollection<Funcionario> funcionario)
        {
            return _mapper.Map<ICollection<FuncionarioViewModel>>(funcionario);
        }

    }
}
