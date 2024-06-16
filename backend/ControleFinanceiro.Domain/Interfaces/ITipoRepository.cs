using ControleFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces
{
    public interface ITipoRepository
    {
        Task<IEnumerable<Tipo>> GetAllAsync();
    }
}
