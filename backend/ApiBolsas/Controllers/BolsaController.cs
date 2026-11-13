using ApiBolsas.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiBolsas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BolsaController : ControllerBase
    {
        private readonly BolsaService _bolsaService;

        public BolsaController(BolsaService bolsaService)
        {
            _bolsaService = bolsaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var bolsas = _bolsaService.ObterBolsas();

            return Ok(bolsas);
        }
    }

}

