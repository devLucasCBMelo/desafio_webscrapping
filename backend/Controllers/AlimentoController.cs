using System.Data;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class AlimentoController : Controller
{
  private readonly AlimentoComponentes _alimentoComponentes;

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

}