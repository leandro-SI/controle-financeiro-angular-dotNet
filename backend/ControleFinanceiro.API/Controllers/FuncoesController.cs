using ControleFinanceiro.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncoesController : ControllerBase
    {
        private readonly IFuncaoService _funcaoService;

        public FuncoesController(IFuncaoService funcaoService)
        {
            _funcaoService = funcaoService;
        }

        
    }
}
