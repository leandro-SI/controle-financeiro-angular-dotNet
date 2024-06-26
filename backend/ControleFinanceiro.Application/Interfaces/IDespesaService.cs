using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Application.Interfaces
{
    public interface IDespesaService
    {
        Task<IEnumerable<DespesaDTO>> GetByUserId(string userId);
        void DeleteDespesas(IEnumerable<DespesaDTO> despesas);
        Task<IEnumerable<DespesaDTO>> GetByCartaoId(long cartaoId);
        Task<DespesaDTO> GetById(long id);
        Task Create(DespesaDTO despesaDTO);
        Task Update(DespesaDTO despesaDTO);
        Task Delete(long id);
    }
}
