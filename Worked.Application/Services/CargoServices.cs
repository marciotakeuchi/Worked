using AutoMapper;
using Worked.Application.Interfaces;
using Worked.Application.ViewModels;
using Worked.Domain.Interfaces;

namespace Worked.Application.Services
{
    public class CargoServices : ICargoServices
    {
        private ICargoRepository _cargoRepository;
        private readonly IMapper _mapper;

        public CargoServices(ICargoRepository cargoRepository, IMapper mapper)
        {
            _cargoRepository = cargoRepository;
            _mapper = mapper;
        }

        public async Task<CargoViewModel> ConsultarPorId(int id)
        {
            var resultado = await _cargoRepository.ConsultarPorId(id);
            return _mapper.Map<CargoViewModel>(resultado);
        }

        public async Task<ICollection<CargoViewModel>> Listar()
        {
            var resultado = await _cargoRepository.Listar();
            return _mapper.Map<ICollection<CargoViewModel>>(resultado);
        }
    }
}
