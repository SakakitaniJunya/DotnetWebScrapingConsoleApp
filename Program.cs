using System;
using System.Net.Http;
using HtmlAgilityPack;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient();
        // スクレイピングするページのリンク
        string url = "https://learn.microsoft.com/ja-jp/training/browse/";
        // ページのHTMLを取得
        string html = await client.GetStringAsync(url);

        HtmlDocument document = new HtmlDocument();
        document.LoadHtml(html);

        var nodes = document.DocumentNode.SelectNodes("//h1");

        if (nodes != null)
        {
            foreach (var node in nodes)
            {
                Console.WriteLine(node.InnerText.Trim());
            }
        }
        else
        {
            Console.WriteLine("No nodes found");
        }
    }

}