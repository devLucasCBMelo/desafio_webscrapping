using System;
using System.Net.Http;
using System.Threading.Tasks;
using backend.Context;
using backend.Entities;
using backend.Models;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;

public class ScrapingService
{
  private readonly HttpClient _httpClient;
  private readonly FoodContext _foodContext;
  private readonly Dictionary<string, object> _componentTables;

  public ScrapingService(HttpClient httpClient, FoodContext foodContext)
  {
    _httpClient = httpClient;
    _foodContext = foodContext;

    _componentTables = new Dictionary<string, object>
    {
      { "EnergiaKJ", _foodContext.EnergiaKJ },
      { "EnergiaKcal", _foodContext.EnergiaKcal },
      { "Umidade", _foodContext.Umidade },
      { "Carboidrato total", _foodContext.CarboidratoTotal },
      { "Carboidrato disponível", _foodContext.CarboidratoDisponivel },
      { "Proteína", _foodContext.Proteina },
      { "Lipídios", _foodContext.Lipidios },
      { "Fibra alimentar", _foodContext.FibraAlimentar },
      { "Álcool", _foodContext.Alcool },
      { "Cinzas", _foodContext.Cinzas },
      { "Colesterol", _foodContext.Colesterol },
      { "Ácidos graxos saturados", _foodContext.AcidosGraxosSaturados },
      { "Ácidos graxos monoinsaturados", _foodContext.AcidosGraxosMonoinsaturados },
      { "Acidos graxos poliinsaturados", _foodContext.AcidosGraxosPoliinsaturados },
      { "AcidosGraxosTrans", _foodContext.AcidosGraxosTrans },
      { "Calcio", _foodContext.Calcio },
      { "Magnesio", _foodContext.Magnesio },
      { "Manganes", _foodContext.Manganes },
      { "Fosforo", _foodContext.Fosforo },
      { "Ferro", _foodContext.Ferro },
      { "Sodio", _foodContext.Sodio },
      { "Potassio", _foodContext.Potassio },
      { "Cobre", _foodContext.Cobre },
      { "Zinco", _foodContext.Zinco },
      { "Selenio", _foodContext.Selenio },
      { "VitaminaA_RE", _foodContext.VitaminaARE },
      { "VitaminaA_RAE", _foodContext.VitaminaARAE },
      { "VitaminaE", _foodContext.VitaminaE },
      { "VitaminaD", _foodContext.VitaminaD },
      { "VitaminaC", _foodContext.VitaminaC },
      { "Tiamina", _foodContext.Tiamina },
      { "Riboflavina", _foodContext.Riboflavina },
      { "Niacina", _foodContext.Niacina },
      { "VitaminaB6", _foodContext.VitaminaB6 },
      { "VitaminaB12", _foodContext.VitaminaB12 },
      { "EquivalenteDeFolato", _foodContext.EquivalenteDeFolato },
      { "SalDeAdicao", _foodContext.SalDeAdicao },
      { "AcucarDeAdicao", _foodContext.AcucarDeAdicao },
    };
  }

  public async Task<string> ObterDadosTBCA()
  {
    string url = "https://www.tbca.net.br/base-dados/composicao_estatistica.php?pagina=1&atuald=1#";
    var response = await _httpClient.GetStringAsync(url);

    var htmlDocument = new HtmlDocument();
    htmlDocument.LoadHtml(response);

    var tabela = htmlDocument.DocumentNode.SelectSingleNode("//table[contains(@class, 'table')]");
    if (tabela == null) return "Tabela não encontrada";

    var linhas = tabela.SelectNodes(".//tr");
    if (linhas == null) return "Nenhuma linha encontrada na tabela!";

    List<Alimento> alimentos = new List<Alimento>();
    string resultado = "";
    foreach (var linha in linhas)
    {
      var colunas = linha.SelectNodes(".//td");
      if (colunas != null && colunas.Count > 0)
      {
        var alimento = new Alimento
        {
          Codigo = colunas[0].InnerText.Trim(),
          Nome = colunas[1].InnerText.Trim(),
          NomeCientifico = string.IsNullOrWhiteSpace(colunas[2].InnerText) ? "--" : colunas[2].InnerText.Trim(),
          Grupo = string.IsNullOrWhiteSpace(colunas[3].InnerText) ? "--" : colunas[3].InnerText.Trim(),
          Marca = string.IsNullOrWhiteSpace(colunas[4].InnerText) ? "--" : colunas[4].InnerText.Trim()
        };

        alimentos.Add(alimento);
        resultado += $"Código: {alimento.Codigo} | Nome: {alimento.Nome} | Nome Científico: {alimento.NomeCientifico} | Grupo: {alimento.Grupo} | Marca: {alimento.Marca} \n";
      }
    }

    await _foodContext.Alimentos.AddRangeAsync(alimentos);
    await _foodContext.SaveChangesAsync();

    return resultado;
  }

  public async Task<string> GetComponentsFood()
  {
    var foodList = await _foodContext.Alimentos.ToListAsync();

    foreach (var food in foodList)
    {
      Console.WriteLine("CADE MINHA TABELAAAAAAAAAAAAAAAAAAAAAA");
      string url = $"https://www.tbca.net.br/base-dados/int_composicao_alimentos.php?cod_produto={food.Codigo}";
      Console.WriteLine(url);

      var response = await _httpClient.GetStringAsync(url);
      var htmlDocument = new HtmlDocument();
      htmlDocument.LoadHtml(response);

      var tabela = htmlDocument.DocumentNode.SelectSingleNode("//*[@id='tabela1']");

      if (tabela == null) return "Tabela não encontrada";

      var linhas = tabela.SelectNodes(".//tr");
      if (linhas == null) return "Nenhuma linha encontrada na tabela!";

      foreach (var linha in linhas)
      {
        var colunas = linha.SelectNodes(".//td");
        if (colunas != null && colunas.Count > 3)
        {
          // Ácidos graxos monoinsaturados
          if (colunas[0].InnerText.Trim() == "Ácidos graxos monoinsaturados")
          {
            var acidosMonoinsaturados = new AcidosGraxosMonoinsaturadosModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.AcidosGraxosMonoinsaturados.AddAsync(acidosMonoinsaturados);
            Console.WriteLine("Ácidos graxos monoinsaturados adicionados.");
          }
          // Ácidos graxos poliinsaturados
          else if (colunas[0].InnerText.Trim() == "Ácidos graxos poliinsaturados")
          {
            var acidosPoliinsaturados = new AcidosGraxosPoliinsaturadosModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.AcidosGraxosPoliinsaturados.AddAsync(acidosPoliinsaturados);
            Console.WriteLine("Ácidos graxos poliinsaturados adicionados.");
          }
          // Ácidos graxos saturados
          else if (colunas[0].InnerText.Trim() == "Ácidos graxos saturados")
          {
            var acidosSaturados = new AcidosGraxosSaturadosModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.AcidosGraxosSaturados.AddAsync(acidosSaturados);
            Console.WriteLine("Ácidos graxos saturados adicionados.");
          }
          // Ácidos graxos trans
          else if (colunas[0].InnerText.Trim() == "Ácidos graxos trans")
          {
            var acidosGraxosTrans = new AcidosGraxosTransModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.AcidosGraxosTrans.AddAsync(acidosGraxosTrans);
            Console.WriteLine("Ácidos graxos saturados adicionados.");
          }
          // Açúcar de Adição
          else if (colunas[0].InnerText.Trim() == "Açúcar de adição")
          {
            var acucarAdicao = new AcucarDeAdicaoModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.AcucarDeAdicao.AddAsync(acucarAdicao);
            Console.WriteLine("Açúcar de adição adicionado.");
          }
          // Álcool
          else if (colunas[0].InnerText.Trim() == "Álcool")
          {
            var alcool = new AlcoolModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.Alcool.AddAsync(alcool);
            Console.WriteLine("Álcool adicionado.");
          }
          // Alfa-tocoferol (Vitamina E)
          else if (colunas[0].InnerText.Trim() == "Vitamina E")
          {
            var vitaminaE = new VitaminaEModelsModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.VitaminaE.AddAsync(vitaminaE);
            Console.WriteLine("Vitamina E adicionada");
          }
          // Cálcio
          else if (colunas[0].InnerText.Trim() == "Cálcio")
          {
            var calcio = new CalcioModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.Calcio.AddAsync(calcio);
            Console.WriteLine("Cálcio adicionado.");
          }
          // Carboidrato disponível
          else if (colunas[0].InnerText.Trim() == "Carboidrato disponível")
          {
            var carboidratoDisponivel = new CarboidratoDisponivelModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.CarboidratoDisponivel.AddAsync(carboidratoDisponivel);
            Console.WriteLine("Carboidrato Disponível adicionado");
          }
          // Carboidrato total
          else if (colunas[0].InnerText.Trim() == "Carboidrato total")
          {
            var carboidratoTotal = new CarboidratoTotalModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.CarboidratoTotal.AddAsync(carboidratoTotal);
            Console.WriteLine("Carboidrato Total adicionado");
          }
          // Cinzas
          else if (colunas[0].InnerText.Trim() == "Cinzas")
          {
            var cinzas = new CinzasModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.Cinzas.AddAsync(cinzas);
            Console.WriteLine("Cinzas adicionado");
          }
          // Cobre
          else if (colunas[0].InnerText.Trim() == "Cobre")
          {
            var cobre = new CobreModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.Cobre.AddAsync(cobre);
            Console.WriteLine("Cobre adicionado");
          }
          // Colesterol
          else if (colunas[0].InnerText.Trim() == "Colesterol")
          {
            var colesterol = new ColesterolModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.Colesterol.AddAsync(colesterol);
            Console.WriteLine("Colesterol adicionado");
          }
          // Energia (kJ e kcal)
          else if (colunas[0].InnerText.Trim() == "Energia")
          {
            if (colunas[1].InnerText.Trim() == "kJ")
            {
              var energiaKJ = new EnergiaKJModels
              {
                Codigo = food.Codigo,
                Unidades = colunas[1].InnerText.Trim(),
                ValorPor100g = colunas[2].InnerText.Trim(),
                ColherSopaCheia45g = colunas[3].InnerText.Trim(),
              };
              await _foodContext.EnergiaKJ.AddAsync(energiaKJ);
              Console.WriteLine("Energia kJ adicionada.");
            }
            else if (colunas[1].InnerText.Trim() == "kcal")
            {
              var energiaKcal = new EnergiaKcalModels
              {
                Codigo = food.Codigo,
                Unidades = colunas[1].InnerText.Trim(),
                ValorPor100g = colunas[2].InnerText.Trim(),
                ColherSopaCheia45g = colunas[3].InnerText.Trim(),
              };
              await _foodContext.EnergiaKcal.AddAsync(energiaKcal);
              Console.WriteLine("Energia kcal adicionada.");
            }
          }

          // Equivalente de folato
          else if (colunas[0].InnerText.Trim() == "Equivalente de folato")
          {
            var folato = new EquivalenteDeFolatoModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.EquivalenteDeFolato.AddAsync(folato);
            Console.WriteLine("Equivalente de folato adicionado");
          }
          // Ferro
          else if (colunas[0].InnerText.Trim() == "Ferro")
          {
            var ferro = new FerroModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.Ferro.AddAsync(ferro);
            Console.WriteLine("Ferro adicionado");
          }
          // Fibra alimentar
          else if (colunas[0].InnerText.Trim() == "Fibra alimentar")
          {
            var fibra = new FibraAlimentarModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.FibraAlimentar.AddAsync(fibra);
            Console.WriteLine("Fibra alimentar adicionada");
          }
          // Fósforo
          else if (colunas[0].InnerText.Trim() == "Fósforo")
          {
            var fosforo = new FosforoModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.Fosforo.AddAsync(fosforo);
            Console.WriteLine("Fósforo adicionado");
          }
          // Lipídios
          else if (colunas[0].InnerText.Trim() == "Lipídios")
          {
            var lipidios = new LipidiosModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.Lipidios.AddAsync(lipidios);
            Console.WriteLine("Lipídios adicionados");
          }
          // Magnésio
          else if (colunas[0].InnerText.Trim() == "Magnésio")
          {
            var magnesio = new MagnesioModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.Magnesio.AddAsync(magnesio);
            Console.WriteLine("Magnésio adicionado");
          }
          // Manganês
          else if (colunas[0].InnerText.Trim() == "Manganês")
          {
            var manganes = new ManganesModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.Manganes.AddAsync(manganes);
            Console.WriteLine("Manganês adicionado");
          }
          // Niacina (Vitamina B3)
          else if (colunas[0].InnerText.Trim() == "Niacina")
          {
            var niacina = new NiacinaModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.Niacina.AddAsync(niacina);
            Console.WriteLine("Niacina adicionada.");
          }
          // Potássio
          else if (colunas[0].InnerText.Trim() == "Potássio")
          {
            var potassio = new PotassioModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.Potassio.AddAsync(potassio);
            Console.WriteLine("Potássio adicionado");
          }
          // Proteína
          else if (colunas[0].InnerText.Trim() == "Proteína")
          {
            var proteina = new ProteinaModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.Proteina.AddAsync(proteina);
            Console.WriteLine("Proteína adicionada");
          }
          //Riboflavina
          else if (colunas[0].InnerText.Trim() == "Riboflavina")
          {
            var riboflavina = new RiboflavinaModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.Riboflavina.AddAsync(riboflavina);
            Console.WriteLine("Riboflavina adicionada.");
          }
          // Sal de adição
          else if (colunas[0].InnerText.Trim() == "Sal de adição")
          {
            var salDeAdicao = new SalDeAdicaoModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.SalDeAdicao.AddAsync(salDeAdicao);
            Console.WriteLine("Sal de Adição adicionado");
          }
          // Selênio
          else if (colunas[0].InnerText.Trim() == "Selênio")
          {
            var selenio = new SelenioModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.Selenio.AddAsync(selenio);
            Console.WriteLine("Selênio adicionado.");
          }
          // Sódio
          else if (colunas[0].InnerText.Trim() == "Sódio")
          {
            var sodio = new SodioModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.Sodio.AddAsync(sodio);
            Console.WriteLine("Sódio adicionado.");
          }
          // Tiamina
          else if (colunas[0].InnerText.Trim() == "Tiamina")
          {
            var tiamina = new TiaminaModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.Tiamina.AddAsync(tiamina);
            Console.WriteLine("Tiamina adicionado");
          }
          // Umidade
          else if (colunas[0].InnerText.Trim() == "Umidade")
          {
            var umidade = new UmidadeModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.Umidade.AddAsync(umidade);
            Console.WriteLine("Umidade adicionada.");
          }
          // Vitamina A (RAE)
          else if (colunas[0].InnerText.Trim() == "Vitamina A (RAE)")
          {
            var vitaminaA = new VitaminaARAEModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.VitaminaARAE.AddAsync(vitaminaA);
            Console.WriteLine("Vitamina A (RAE) adicionada.");
          }
          // Vitamina A (RE)
          else if (colunas[0].InnerText.Trim() == "Vitamina A (RE)")
          {
            var vitaminaA = new VitaminaAREModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.VitaminaARE.AddAsync(vitaminaA);
            Console.WriteLine("Vitamina A (RE) adicionada.");
          }
          // Vitamina B12
          else if (colunas[0].InnerText.Trim() == "Vitamina B12")
          {
            var vitaminaB12 = new VitaminaB12Models
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.VitaminaB12.AddAsync(vitaminaB12);
            Console.WriteLine("Vitamina B12 adicionada.");
          }
          // Vitamina B6 (Piridoxina)
          else if (colunas[0].InnerText.Trim() == "Vitamina B6")
          {
            var vitaminaB6 = new VitaminaB6Models
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.VitaminaB6.AddAsync(vitaminaB6);
            Console.WriteLine("Vitamina B6 adicionada.");
          }
          // Vitamina C (Ácido ascórbico)
          else if (colunas[0].InnerText.Trim() == "Vitamina C")
          {
            var vitaminaC = new VitaminaCModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.VitaminaC.AddAsync(vitaminaC);
            Console.WriteLine("Vitamina C adicionada.");
          }
          // Vitamina D
          else if (colunas[0].InnerText.Trim() == "Vitamina D")
          {
            var vitaminaD = new VitaminaDModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.VitaminaD.AddAsync(vitaminaD);
            Console.WriteLine("Vitamina D adicionada.");
          }
          // Zinco
          else if (colunas[0].InnerText.Trim() == "Zinco")
          {
            var zinco = new ZincoModels
            {
              Codigo = food.Codigo,
              Unidades = colunas[1].InnerText.Trim(),
              ValorPor100g = colunas[2].InnerText.Trim(),
              ColherSopaCheia45g = colunas[3].InnerText.Trim(),
            };
            await _foodContext.Zinco.AddAsync(zinco);
            Console.WriteLine("Zinco adicionado.");
          }

        }
      }

      await _foodContext.SaveChangesAsync();
    }

    return "Sucesso";
  }
}