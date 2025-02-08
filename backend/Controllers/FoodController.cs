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
    Console.WriteLine(alimentos);
    if (alimentos == null)
    {
      return NotFound();
    }

    return Ok(alimentos);
  }

}