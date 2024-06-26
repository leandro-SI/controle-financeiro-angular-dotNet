using AutoMapper;
using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces;

namespace ControleFinanceiro.Application.Services
{
    public class DespesaService : IDespesaService
    {
        private readonly IDespesaRepository _despesaRepository;
        private readonly IMapper _mapper;

        public DespesaService(IDespesaRepository despesaRepository, IMapper mapper)
        {
            _despesaRepository = despesaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DespesaDTO>> GetByUserId(string userId)
        {
            var despesa = await _despesaRepository.GetByUserId(userId);

            return _mapper.Map<IEnumerable<DespesaDTO>>(despesa);
        }

        public void DeleteDespesas(IEnumerable<DespesaDTO> despesas)
        {
            var entities = _mapper.Map<IEnumerable<Despesa>>(despesas);

            _despesaRepository.DeleteDespesas(entities);
        }

        public async Task<IEnumerable<DespesaDTO>> GetByCartaoId(long cartaoId)
        {
            var despesas = await _despesaRepository.GetByCartaoId(cartaoId);

            return _mapper.Map<IEnumerable<DespesaDTO>>(despesas);
        }

        public async Task<DespesaDTO> GetById(long id)
        {
            var despesa = await _despesaRepository.FindById(id);

            return _mapper.Map<DespesaDTO>(despesa);
        }

        public async Task Create(DespesaDTO despesaDTO)
        {
            var despesa = _mapper.Map<Despesa>(despesaDTO);

            await _despesaRepository.Create(despesa);
        }

        public async Task Update(DespesaDTO despesaDTO)
        {
            var despesa = _mapper.Map<Despesa>(despesaDTO);

            await _despesaRepository.Update(despesa);
        }

        public async Task Delete(long id)
        {
            await _despesaRepository.Delete(id);
        }
    }
}
