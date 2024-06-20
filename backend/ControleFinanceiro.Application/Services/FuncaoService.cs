using AutoMapper;
using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Application.Services
{
    public class FuncaoService : IFuncaoService
    {
        private readonly IFuncaoRepository _funcaoRepository;
        private readonly IMapper _mapper;

        public FuncaoService(IFuncaoRepository funcaoRepository, IMapper mapper)
        {
            _funcaoRepository = funcaoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FuncaoDTO>> GetAll()
        {
            var entities = await _funcaoRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<FuncaoDTO>>(entities);
        }

        public async Task<FuncaoDTO> GetById(string id)
        {
            var entityDto = await _funcaoRepository.GetByIdAsync(id);

            return _mapper.Map<FuncaoDTO>(entityDto);
        }

        public async Task Adicionar(FuncaoDTO funcaoDto)
        {
            var entity = _mapper.Map<Funcao>(funcaoDto);

            await _funcaoRepository.AdicionarAsync(entity);
        }

        public async Task Atualizar(FuncaoDTO funcaoDto)
        {
            var funcao = await _funcaoRepository.GetByIdAsync(funcaoDto.Id);
            funcao.Name = funcaoDto.Name;
            funcao.NormalizedName = funcaoDto.NormalizedName;
            funcao.Descricao = funcaoDto.Descricao;

            await _funcaoRepository.AtualizarAsync(funcao);
        }

        public async Task Delete(FuncaoDTO funcaoDTO)
        {
            var entity = _mapper.Map<Funcao>(funcaoDTO);

            await _funcaoRepository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<FuncaoDTO>> Filtrar(string nome)
        {
            var funcoes = await _funcaoRepository.Filtrar(nome);

            var filterResult = _mapper.Map<IEnumerable<FuncaoDTO>>(funcoes).ToList();

            return filterResult;
        }
    }
}
