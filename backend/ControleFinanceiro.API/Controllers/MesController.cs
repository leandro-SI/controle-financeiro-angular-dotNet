using ControleFinanceiro.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesController : ControllerBase
    {
        private readonly IMesService _mesService;

        public MesController(IMesService mesService)
        {
            _mesService = mesService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var meses = await _mesService.GetAll();

            return Ok(meses);
        }
    }
}
