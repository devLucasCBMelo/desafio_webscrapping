using System.Data;
using backend.Context;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class FoodController : Controller
{

  private readonly FoodContext _foodContext;

  public FoodController(FoodContext foodContext)
  {
    _foodContext = foodContext ?? throw new ArgumentNullException(nameof(foodContext));
  }

  [HttpGet()]
  public async Task<IActionResult> GetAllFoods()
  {
    var alimentos = await _foodContext.Alimentos.ToListAsync();
    if (alimentos == null)
    {
      return NotFound();
    }

    return Ok(alimentos);
  }

  [HttpGet("{foodCode}")]
  public async Task<IActionResult> GetFoodByCode(string foodCode)
  {
    var alimentos = await _foodContext.Alimentos
      .Where(x => x.Codigo.StartsWith(foodCode))
      .ToListAsync();

    if (alimentos == null)
    {
      return NotFound();
    }

    return Ok(alimentos);
  }

}