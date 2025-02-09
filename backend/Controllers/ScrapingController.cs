using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/scraping")]
public class ScrapingController : ControllerBase
{
  private readonly ScrapingService _scrapingService;

  public ScrapingController(ScrapingService scrapingService)
  {
    _scrapingService = scrapingService;
  }

  [HttpGet("tbca")]
  public async Task<IActionResult> ObterDados()
  {
    var resultado = await _scrapingService.ObterDadosTBCA();
    return Ok(resultado);
  }

  [HttpGet()]
  public async Task<IActionResult> ObterComponentesDosAlimentos()
  {
    var resultado = await _scrapingService.GetComponentsFood();
    return Ok(resultado);
  }
}