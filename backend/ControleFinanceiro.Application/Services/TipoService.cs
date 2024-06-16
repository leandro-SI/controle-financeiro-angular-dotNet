using AutoMapper;
using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Domain.Interfaces;

namespace ControleFinanceiro.Application.Services
{
    public class TipoService : ITipoService
    {
        private readonly ITipoRepository _tipoRepository;
        private readonly IMapper _mapper;

        public TipoService(ITipoRepository tipoRepository, IMapper mapper)
        {
            _tipoRepository = tipoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoDTO>> GetAll()
        {
            var entities = await _tipoRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<TipoDTO>>(entities);
        }
    }
}
