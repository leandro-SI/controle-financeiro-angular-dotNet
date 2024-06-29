using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ICartaoService _cartaoService;
        private readonly IGanhoService _ganhoService;
        private readonly IDespesaService _despesaService;
        private readonly IMesService _mesService;
        private readonly IGraficoRepository _graficoRepository;

        public DashboardController(ICartaoService cartaoService, IGanhoService ganhoService, IDespesaService despesaService, IMesService mesService, IGraficoRepository graficoRepository)
        {
            _cartaoService = cartaoService;
            _ganhoService = ganhoService;
            _despesaService = despesaService;
            _mesService = mesService;
            _graficoRepository = graficoRepository;
        }

        [HttpGet("get-cards/{userId}")]
        public async Task<IActionResult> GetDadosCards(string userId)
        {
            int qtdCartoes = await _cartaoService.GetQuantidadeByUser(userId);
            decimal ganhoTotal = Math.Round(await _ganhoService.GetGanhoTotalByUserId(userId), 2);
            decimal despesaTotal = Math.Round(await _despesaService.GetDespesaTotalByUserId(userId), 2);
            decimal saldo = Math.Round(ganhoTotal - despesaTotal, 2);

            var cardDashboard = new CardDashboardDTO
            {
                QtdCartoes = qtdCartoes,
                GanhoTotal = ganhoTotal,
                DespesaTotal = despesaTotal,
                Saldo = saldo
            };

            return Ok(cardDashboard);
        }

        [HttpGet("get-dados-anuais-by-user/{userId}/{ano}")]
        public async Task<IActionResult> GetDadosAnuaisByUsuarioId(string userId, int ano)
        {
            return Ok(new
            {
                ganhos = await _graficoRepository.GetGanhosAnuaisByUsuarioId(userId, ano),
                despesas = await _graficoRepository.GetDespesasAnuaisByUsuarioId(userId, ano),
                meses = await _mesService.GetAll()
            });
        }

    }
}
