using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Application.Interfaces
{
    public interface IGanhoService
    {
        Task<IEnumerable<GanhoDTO>> GetByUserId(string userId);
        void DeleteGanhos(IEnumerable<GanhoDTO> ganhos);
        Task<GanhoDTO> GetById(long id);
        Task Create(GanhoDTO ganhoDto);
        Task Update(GanhoDTO ganhoDto);
        Task Delete(long id);
        Task<IEnumerable<GanhoDTO>> Filtrar(string nomeCategoria, string tipo);
        Task<decimal> GetGanhoTotalByUserId(string userId);
    }
}
