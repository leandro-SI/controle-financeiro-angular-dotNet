using ControleFinanceiro.Application.Dtos;

namespace ControleFinanceiro.Application.Interfaces
{
    public interface ICartaoService
    {
        Task<IEnumerable<CartaoDTO>> GetByUserId(string id);
        Task<CartaoDTO> GetById(long id);
        Task Update(CartaoDTO cartaoDTO);
        Task Create(CartaoDTO cartaoDTO);
        Task Delete(long id);
        Task<IEnumerable<CartaoDTO>> Filtrar(string nome);
        Task<int> GetQuantidadeByUser(string userId);
    }
}
