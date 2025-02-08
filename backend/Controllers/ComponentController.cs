using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using backend.Context;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComponentController : Controller
    {
        private readonly FoodComponent _foodComponent;
        private readonly FoodContext _foodContext;

        private readonly EnergiaService _energiaService;

        private readonly AlcoolService _alcoolService;

        public ComponentController(FoodComponent foodComponent, FoodContext foodContext)
        {
            _foodComponent = foodComponent ?? throw new ArgumentNullException(nameof(foodComponent));
            _foodContext = foodContext ?? throw new ArgumentNullException(nameof(foodContext));

        }

        [HttpGet("{foodCode}")]
        public async Task<IActionResult> ObterComponentes(string foodCode)
        {
            var resultado = await _foodComponent.ObterDadosComponentes(foodCode);

            if (resultado == null)
            {
                return NotFound(new { Message = "Componente não encontrado ou erro ao buscar dados." });
            }

            return Ok(resultado);
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AdicionarEnergiaKJ([FromBody] ComponenteAlimento componente)
        {
            if (componente == null)
            {
                return BadRequest(new { Message = "Dados do componente não podem ser vazios" });
            }

            var energia = new EnergiaKJModels
            {
                Unidades = componente.Unidades,
                ValorPor100g = componente.ValorPor100g,
                ColherSopaCheia45g = componente.ColherSopaCheia45g,
                CopoAmericanoDuplo200ml = componente.CopoAmericanoDuplo200ml,
                CopoAmericanoPequeno130ml = componente.CopoAmericanoPequeno130ml,
                PedacoUnidadeFatia = componente.PedacoUnidadeFatia,
                PratoFundo450g = componente.PratoFundo450g,
                PratoRaso350g = componente.PratoRaso350g
            };

            /* await _energiaService.AdicionarEnergia(energia);
            return CreatedAtAction(nameof(AdicionarEnergiaKJ), new { codigo = energia.Cogido }, energia); */
            return Ok(energia);
        }

        [HttpPost("AdicionarAlcool")]
        public async Task<IActionResult> AdicionarAlcool([FromBody] ComponenteAlimento componente)
        {
            if (componente == null)
            {
                return BadRequest(new { Message = "Dados do componente não podem ser vazios" });
            }

            var alcool = new AlcoolModels
            {
                Cogido = componente.Cogido,
                Unidades = componente.Unidades,
                ValorPor100g = componente.ValorPor100g,
                ColherSopaCheia45g = componente.ColherSopaCheia45g,
                CopoAmericanoDuplo200ml = componente.CopoAmericanoDuplo200ml,
                CopoAmericanoPequeno130ml = componente.CopoAmericanoPequeno130ml,
                PedacoUnidadeFatia = componente.PedacoUnidadeFatia,
                PratoFundo450g = componente.PratoFundo450g,
                PratoRaso350g = componente.PratoRaso350g
            };

            Console.WriteLine(alcool);
            await _alcoolService.AdicionarAlcool(alcool);
            return CreatedAtAction(nameof(AdicionarAlcool), new { codigo = alcool.Cogido }, alcool);
        }
    }
}