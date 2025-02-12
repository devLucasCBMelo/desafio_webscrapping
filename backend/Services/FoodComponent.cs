using System;
using System.Net.Http;
using System.Threading.Tasks;
using backend.Context;
using backend.Helpers;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    // Classe para representar as informações de componentes de um alimento
    public class ComponenteAlimento
    {
        public string Codigo { get; set; }
        public string Unidades { get; set; }
        public string ValorPor100g { get; set; }

        public string ColherSopaCheia45g { get; set; }
        public string CopoAmericanoDuplo200ml { get; set; }
        public string CopoAmericanoPequeno130ml { get; set; }
        public string PedacoUnidadeFatia { get; set; }
        public string PratoFundo450g { get; set; }
        public string PratoRaso350g { get; set; }
    }

    public class FoodComponent
    {
        private readonly HttpClient _httpClient;
        private readonly FoodContext _foodContext;

        public FoodComponent(HttpClient httpClient, FoodContext foodContext)
        {
            _httpClient = httpClient;
            _foodContext = foodContext;
        }

        public async Task<object> ObterDadosComponentes(string foodCode)
        {
            var componentes = await _foodContext.Alimentos
                .Include(a => a.acidosGraxosPoliinsaturados)
                .Include(a => a.acidosGraxosMonoinsaturados) //não apareceu
                .Include(a => a.acidosGraxosSaturados)
                .Include(a => a.acidosGraxosTransModels)
                .Include(a => a.acucarDeAdicao)
                .Include(a => a.alcool)
                .Include(a => a.calcios)
                .Include(a => a.carboidratoDisponivel)
                .Include(a => a.carboidratoTotal)
                .Include(a => a.cinzas)
                .Include(a => a.cobre)
                .Include(a => a.colesterol)
                .Include(a => a.energiaKcal)
                .Include(a => a.energiaKJs)
                .Include(a => a.equivalenteDeFolato)
                .Include(a => a.ferro)
                .Include(a => a.fibraAlimentar)
                .Include(a => a.fosforo)
                .Include(a => a.lipidios)
                .Include(a => a.magnesio)
                .Include(a => a.manganes)
                .Include(a => a.niacina)
                .Include(a => a.potassio)
                .Include(a => a.proteina)
                .Include(a => a.riboflavina)
                .Include(a => a.salDeAdicao)
                .Include(a => a.selenio)
                .Include(a => a.sodio)
                .Include(a => a.tiamina)
                .Include(a => a.umidade)
                .Include(a => a.vitaminaARAE)
                .Include(a => a.vitaminaARE)
                .Include(a => a.vitaminaB12)
                .Include(a => a.vitaminaB6)
                .Include(a => a.vitaminaC)
                .Include(a => a.vitaminaD)
                .Include(a => a.vitaminaE)
                .Include(a => a.zinco)
                .FirstOrDefaultAsync(a => a.Codigo == foodCode);
            return componentes;
        }

    }
}
