using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Interfaces;
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

        public DashboardController(ICartaoService cartaoService, IGanhoService ganhoService, IDespesaService despesaService, IMesService mesService)
        {
            _cartaoService = cartaoService;
            _ganhoService = ganhoService;
            _despesaService = despesaService;
            _mesService = mesService;
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

    }
}
