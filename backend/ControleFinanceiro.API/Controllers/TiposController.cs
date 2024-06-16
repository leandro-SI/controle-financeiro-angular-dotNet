using ControleFinanceiro.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposController : ControllerBase
    {
        private readonly ITipoService _tiposService;

        public TiposController(ITipoService tiposService)
        {
            _tiposService = tiposService;
        }


        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var tipos = await _tiposService.GetAll();

            if (tipos == null)
                return NotFound();

            return Ok(tipos);
        }
    }
}
