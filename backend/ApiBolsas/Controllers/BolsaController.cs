using ApiBolsas.DTOs;
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

        [HttpGet("tipos")]
        public IActionResult GetTipos() => Ok(_bolsaService.ObterBolsas());


        [HttpGet]
        public IActionResult Get()
        {
            var bolsas = _bolsaService.Listar();

            return Ok(bolsas);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BolsasDTO bolsa)
        {
            var criada = _bolsaService.Adicionar(bolsa);
            return Ok(criada);
        }

        [HttpDelete("{codigo}")] 
        public IActionResult Delete(int codigo)
        {
            return _bolsaService.Remover(codigo) ? NoContent() : NotFound();
        }

        [HttpPut("{codigo}")]
        public IActionResult Put(int codigo, [FromBody] BolsasDTO dados)
        {
            var atualizada = _bolsaService.Atualizar(codigo,dados);
            return atualizada == null ? NotFound() : Ok(atualizada);
        }

    }

}

