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
    }
}