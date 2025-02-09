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
      { "Carboidrado disponível", _foodContext.CarboidratoDisponivel },
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
          NomeCientifico = colunas[2].InnerText.Trim(),
          Grupo = colunas[3].InnerText.Trim(),
          Marca = colunas[4].InnerText.Trim()
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
          // Energia kJ
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
          }
          // Outros componentes como Açúcar de adição, Cálcio, etc.
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
          // Continue para outros componentes
        }
      }

      await _foodContext.SaveChangesAsync();
    }

    return "Sucesso";
  }


  /* public async Task<string> GetComponentsFood()
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
        if (colunas != null && colunas.Count > 1)
        {
          string nomeComponente = colunas[0].InnerText.Trim();
          string unidade = colunas[1].InnerText.Trim();
          string valorPor100g = colunas[2].InnerText.Trim();
          string colherSopaCheia = colunas[3].InnerText.Trim();
          string colherSopaRasa = colunas[4].InnerText.Trim();
          Console.WriteLine($"Componente: {nomeComponente} | Unidade: {unidade} | Unidade: {valorPor100g} | colherSopa: {colherSopaCheia}");
          if (nomeComponente == "Energia")
          {
            var energiaKJ = new EnergiaKJModels
            {
              Unidades = unidade,
              ValorPor100g = valorPor100g,
              ColherSopaCheia45g = colherSopaCheia,
            };

            await _foodContext.EnergiaKJ.AddAsync(energiaKJ);
          }
        }
      }
    }

    return "Sucesso";
  } */
}