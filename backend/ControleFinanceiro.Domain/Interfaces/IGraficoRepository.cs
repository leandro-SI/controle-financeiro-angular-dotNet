using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces
{
    public interface IGraficoRepository
    {
        object GetGanhosAnuaisByUsuarioId(string userId, int ano);
        object GetDespesasAnuaisByUsuarioId(string userId, int ano);
    }
}
