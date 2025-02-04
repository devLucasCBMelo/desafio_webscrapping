using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

public class ScrapingService
{
  private readonly HttpClient _httpClient;

  public ScrapingService(HttpClient httpClient)
  {
    _httpClient = httpClient;
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

    string resultado = "";
    foreach (var linha in linhas)
    {
      var colunas = linha.SelectNodes(".//td");
      if (colunas != null && colunas.Count > 0)
      {
        string codigo = colunas[0].InnerText.Trim();
        string nome = colunas[1].InnerText.Trim();
        string nomeCientifico = colunas[2].InnerText.Trim();
        string grupo = colunas[3].InnerText.Trim();
        string marca = colunas[4].InnerText.Trim();
        resultado += $"Código: {codigo} | Nome: {nome} | Nome Científico: {nomeCientifico} | Grupo: {grupo} | Marca: {marca} \n";
      }
    }

    return resultado;
  }
}