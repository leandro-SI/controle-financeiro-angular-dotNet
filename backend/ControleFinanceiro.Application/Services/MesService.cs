using AutoMapper;
using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Domain.Interfaces;

namespace ControleFinanceiro.Application.Services
{
    public class MesService : IMesService
    {
        private readonly IMesRepository _mesRepository;
        private readonly IMapper _mapper;

        public MesService(IMesRepository mesRepository, IMapper mapper)
        {
            _mesRepository = mesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MesDTO>> GetAll()
        {
            var meses = await _mesRepository.FindAll();

            meses = meses.OrderBy(m => m.Id);

            return _mapper.Map<IEnumerable<MesDTO>>(meses);
        }
    }
}
