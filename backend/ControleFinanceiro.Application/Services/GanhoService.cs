using AutoMapper;
using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infra.Data.Repositories;

namespace ControleFinanceiro.Application.Services
{
    public class GanhoService : IGanhoService
    {
        private readonly IGanhoRepository _ganhoRepository;
        private readonly IMapper _mapper;

        public GanhoService(IGanhoRepository ganhoRepository, IMapper mapper)
        {
            _ganhoRepository = ganhoRepository;
            _mapper = mapper;
        }

        public async Task<GanhoDTO> GetById(long id)
        {
            var ganhos = await _ganhoRepository.FindById(id);

            return _mapper.Map<GanhoDTO>(ganhos);
        }

        public async Task<IEnumerable<GanhoDTO>> GetByUserId(string userId)
        {
            var ganhos = await _ganhoRepository.GetByUserId(userId);

            return _mapper.Map<IEnumerable<GanhoDTO>>(ganhos);
        }

        public async Task Create(GanhoDTO ganhoDto)
        {
            var ganho = _mapper.Map<Ganho>(ganhoDto);

            await _ganhoRepository.Create(ganho);
        }

        public async Task Update(GanhoDTO ganhoDto)
        {
            var ganho = _mapper.Map<Ganho>(ganhoDto);

            await _ganhoRepository.Update(ganho);
        }

        public async Task Delete(long id)
        {
            await _ganhoRepository.Delete(id);
        }

        public void DeleteGanhos(IEnumerable<GanhoDTO> ganhos)
        {
            var entities = _mapper.Map<IEnumerable<Ganho>>(ganhos);

            _ganhoRepository.DeleteGanhos(entities);
        }

        public async Task<IEnumerable<GanhoDTO>> Filtrar(string nomeCategoria, string tipo)
        {
            var ganhos = await _ganhoRepository.Filtrar(nomeCategoria, tipo);

            return _mapper.Map<IEnumerable<GanhoDTO>>(ganhos);
        }
    }
}
