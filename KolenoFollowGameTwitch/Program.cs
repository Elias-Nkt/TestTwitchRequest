using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace KolenoFollowGameTwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            var Follow = Test();

            Console.ReadKey();
        }

        static async Task Test()
        {
            var r = await DownloadPage();
            if (r == null)
            {
                Console.WriteLine("Ne Gusto tut!!");
            }
            Console.WriteLine(r.Substring(0, 1000) + "\n\n" + "//End 1000chars");

        }

        static async Task<string> DownloadPage()
        {
            var client = new HttpClient();
            string URL = string.Format("https://api.twitch.tv/api/users/{0}/follows/games/live", "Elias_nktn");
            client.DefaultRequestHeaders.Add("Client-ID", "l0h8dwzkv4cf9gejv1ru661c6dvjj9");
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.twitchtv.v5+json");

            var r = await client.GetAsync(new Uri(URL));
            //r.Headers.Add();
            string result = await r.Content.ReadAsStringAsync();
            return result;
        }
    }
}
