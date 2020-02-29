using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cwiczenie1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
            var client = new HttpClient();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string html = await response.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[z-z0-9]*@[a-z0-9]+\\.[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);
                MatchCollection matches = regex.Matches(html);
                foreach (var m in matches)
                {
                    Console.WriteLine(m);
                }
            }

            Console.WriteLine("Koniec!");
        }
    }
}
