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

    /* public async Task<ComponenteAlimento> ObterDadosComponentes(string codigoDoAlimento)
        {
            string url = $"https://www.tbca.net.br/base-dados/int_composicao_alimentos.php?cod_produto={codigoDoAlimento}";
            var response = await _httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(response);

            var unidadesNode = CheckNodes.ObterNodeOuNull(htmlDocument, "//table/tbody/tr[1]/td[2]", "unidade");
            var valorPor100gNode = CheckNodes.ObterNodeOuNull(htmlDocument, "//table/tbody/tr[1]/td[3]", "valor por 100g");
            var colherSopaCheia45gNode = CheckNodes.ObterNodeOuNull(htmlDocument, "//table/tbody/tr[1]/td[4]", "colher de sopa cheia");
            var copoAmericanoDuplo200mlNode = CheckNodes.ObterNodeOuNull(htmlDocument, "//table/tbody/tr[1]/td[5]", "Copo Americano Duplo 200mL");
            var copoAmericanoPequeno130mlNode = CheckNodes.ObterNodeOuNull(htmlDocument, "//table/tbody/tr[1]/td[6]", "Copo Americano Pequeno 130mL");
            var pedacoUnidadeFatiaNode = CheckNodes.ObterNodeOuNull(htmlDocument, "//table/tbody/tr[1]/td[7]", "Pedaço/UnidadeFatia(M)");
            var pratoFundo450gNode = CheckNodes.ObterNodeOuNull(htmlDocument, "//table/tbody/tr[1]/td[8]", "Prato Fundo");
            var pratoRaso350gNode = CheckNodes.ObterNodeOuNull(htmlDocument, "//table/tbody/tr[1]/td[9]", "Prato Raso");

            // Se algum dos nós não foi encontrado, retorna null
            if (unidadesNode == null || valorPor100gNode == null || colherSopaCheia45gNode == null ||
                copoAmericanoDuplo200mlNode == null || copoAmericanoPequeno130mlNode == null ||
                pedacoUnidadeFatiaNode == null || pratoFundo450gNode == null || pratoRaso350gNode == null)
            {
                return null;
            }

            string unidades = unidadesNode.InnerText.Trim();
            string valorPor100g = valorPor100gNode.InnerText.Trim();
            string colherSopaCheia45g = colherSopaCheia45gNode.InnerText.Trim();
            string copoAmericanoDuplo200ml = copoAmericanoDuplo200mlNode.InnerText.Trim();
            string copoAmericanoPequeno130ml = copoAmericanoPequeno130mlNode.InnerText.Trim();
            string pedacoUnidadeFatia = pedacoUnidadeFatiaNode.InnerText.Trim();
            string pratoFundo450g = pratoFundo450gNode.InnerText.Trim();
            string pratoRaso350g = pratoRaso350gNode.InnerText.Trim();
            Console.WriteLine($"📌 Valor por 100g: {valorPor100g}");

            // Retorna o objeto com as informações
            return new ComponenteAlimento
            {
                Unidades = unidades,
                ValorPor100g = valorPor100g,
                ColherSopaCheia45g = colherSopaCheia45g,
                CopoAmericanoDuplo200ml = copoAmericanoDuplo200ml,
                CopoAmericanoPequeno130ml = copoAmericanoPequeno130ml,
                PedacoUnidadeFatia = pedacoUnidadeFatia,
                PratoFundo450g = pratoFundo450g,
                PratoRaso350g = pratoRaso350g,
            };
        }
    } */
}
