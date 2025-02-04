using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace backend.Helpers
{
    public class CheckNodes
    {
        public static HtmlNode? ObterNodeOuNull(HtmlDocument document, string xpath, string descricaoElemento)
        {
            var node = document.DocumentNode.SelectSingleNode(xpath);
            if (node == null)
            {
                Console.WriteLine($"⚠️ Não foi possível encontrar o elemento {descricaoElemento}.");
            }
            return node;
        }
    }
}