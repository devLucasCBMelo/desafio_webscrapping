using System;
using System.Net.Http;
using System.Threading.Tasks;
using backend.Context;
using backend.Entities;
using HtmlAgilityPack;

public class ScrapingService
{
  private readonly HttpClient _httpClient;
  private readonly AlimentoContexto _alimentoContexto;

  public ScrapingService(HttpClient httpClient, AlimentoContexto alimentoContexto)
  {
    _httpClient = httpClient;
    _alimentoContexto = alimentoContexto;
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

    await _alimentoContexto.Alimentos.AddRangeAsync(alimentos);
    await _alimentoContexto.SaveChangesAsync();

    return resultado;
  }
}