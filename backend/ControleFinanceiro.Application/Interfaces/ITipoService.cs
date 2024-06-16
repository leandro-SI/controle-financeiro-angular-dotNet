using ControleFinanceiro.Application.Dtos;

namespace ControleFinanceiro.Application.Interfaces
{
    public interface ITipoService
    {
        Task<IEnumerable<TipoDTO>> GetAll();
    }
}
