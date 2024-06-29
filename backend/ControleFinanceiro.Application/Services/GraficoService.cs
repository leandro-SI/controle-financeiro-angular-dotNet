using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Application.Services
{
    public class GraficoService : IGraficoService
    {
        private readonly IGraficoRepository _graficoRepository;

        public GraficoService(IGraficoRepository graficoRepository)
        {
            _graficoRepository = graficoRepository;
        }

        public async Task<object> GetDespesasAnuaisByUsuarioId(string userId, int ano)
        {
            return await _graficoRepository.GetDespesasAnuaisByUsuarioId(userId, ano);
        }

        public async Task<object> GetGanhosAnuaisByUsuarioId(string userId, int ano)
        {
            return await _graficoRepository.GetGanhosAnuaisByUsuarioId(userId, ano);
        }
    }
}
