﻿using AutoMapper;
using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces;

namespace ControleFinanceiro.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDTO>> GetAll()
        {
            var entity = await _categoriaRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<CategoriaDTO>>(entity);
        }

        public async Task<CategoriaDTO> GetById(long id)
        {
            var entity = await _categoriaRepository.GetByIdAsync(id);

            return _mapper.Map<CategoriaDTO>(entity);
        }

        public async Task Create(CategoriaDTO categoriaDto)
        {
            var entity = _mapper.Map<Categoria>(categoriaDto);

            await _categoriaRepository.CreateAsync(entity);
        }

        public async Task Update(CategoriaDTO categoriaDto)
        {
            var entity = _mapper.Map<Categoria>(categoriaDto);

            await _categoriaRepository.UpdateAsync(entity);
        }

        public async Task Delete(long id)
        {
            var entity = _categoriaRepository.GetByIdAsync(id).Result;
            
            await _categoriaRepository.DeleteAsync(entity);
        }

    }
}