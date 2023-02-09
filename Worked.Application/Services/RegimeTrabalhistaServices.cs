using AutoMapper;
using Worked.Application.Interfaces;
using Worked.Application.ViewModels;
using Worked.Domain.Interfaces;

namespace Worked.Application.Services
{
    public class RegimeTrabalhistaServices : IRegimeTrabalhistaServices
    {
        private IRegimeTrabalhistaRepository _regimeTrabalhistaRepsitory;
        private readonly IMapper _mapper;

        public RegimeTrabalhistaServices(IRegimeTrabalhistaRepository regimeTrabalhistaRepsitory, IMapper mapper)
        {
            _regimeTrabalhistaRepsitory = regimeTrabalhistaRepsitory;
            _mapper = mapper;
        }

        public async Task<RegimeTrabalhistaViewModel> ConsultarPorId(int id)
        {
            var resultado = await _regimeTrabalhistaRepsitory.ConsultarPorId(id);
            return _mapper.Map<RegimeTrabalhistaViewModel>(resultado);
        }

        public async Task<ICollection<RegimeTrabalhistaViewModel>> Listar()
        {
            var resultado = await _regimeTrabalhistaRepsitory.Listar();
            return _mapper.Map<ICollection<RegimeTrabalhistaViewModel>>(resultado);
        }
    }
}
