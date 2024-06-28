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
    public class CartaoService : ICartaoService
    {
        private readonly ICartaoRepository _cartaoRepository;
        private readonly IMapper _mapper;

        public CartaoService(ICartaoRepository cartaoRepository, IMapper mapper)
        {
            _cartaoRepository = cartaoRepository;
            _mapper = mapper;
        }

        public async Task Create(CartaoDTO cartaoDTO)
        {
            var cartao = _mapper.Map<Cartao>(cartaoDTO);

            await _cartaoRepository.Create(cartao);
        }

        public async Task<CartaoDTO> GetById(long id)
        {
            var cartao = await _cartaoRepository.FindById(id);

            return _mapper.Map<CartaoDTO>(cartao);
        }

        public async Task<IEnumerable<CartaoDTO>> GetByUserId(string id)
        {
            var cartoes = await _cartaoRepository.GetByUserId(id);

            return _mapper.Map<IEnumerable<CartaoDTO>>(cartoes);
        }

        public async Task Update(CartaoDTO cartaoDTO)
        {
            var cartao = _mapper.Map<Cartao>(cartaoDTO);

            await _cartaoRepository.Update(cartao);
        }

        public async Task Delete(long id)
        {
            await _cartaoRepository.Delete(id);
        }

        public async Task<IEnumerable<CartaoDTO>> Filtrar(string nome)
        {
            var cartoes = await _cartaoRepository.Filtrar(nome);

            return _mapper.Map<IEnumerable<CartaoDTO>>(cartoes).ToList();
  
        }

        public async Task<int> GetQuantidadeByUser(string userId)
        {
            return await _cartaoRepository.GetQuantidadeByUser(userId);
        }
    }
}
