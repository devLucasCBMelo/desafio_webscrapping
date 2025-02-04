using System.Data;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class AlimentoController : Controller
{
  private readonly AlimentoComponentes _alimentoComponentes;
  private readonly EnergiaService _energiaService;

  public AlimentoController(AlimentoComponentes alimentoComponentes)
  {
    _alimentoComponentes = alimentoComponentes ?? throw new ArgumentNullException(nameof(alimentoComponentes));
  }

  [HttpGet]
  public string Get() => "Hello world";

  [HttpGet("componentes/{codigoDoAlimento}")]
  public async Task<IActionResult> ObterComponentes(string codigoDoAlimento)
  {
    var resultado = await _alimentoComponentes.ObterDadosComponentes(codigoDoAlimento);

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

}