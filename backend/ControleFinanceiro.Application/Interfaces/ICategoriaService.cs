﻿using ControleFinanceiro.Application.Dtos;

namespace ControleFinanceiro.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDTO>> GetAll();
        Task<CategoriaDTO> GetById(long id);
        Task Create(CategoriaDTO categoriaDto);
        Task Update(CategoriaDTO categoriaDto);
        Task Delete(long id);
        Task<IEnumerable<CategoriaDTO>> Filtrar(string nome);
        Task<IEnumerable<CategoriaDTO>> GetByTipo(string tipo);
    }
}
