using System;
using System.Net.Http;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace KanyeRest
{
    class Program
    {
        static void Main(string[] args)
        {
            var kanyeURL = "https://api.kanye.rest";

            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            var client = new HttpClient();

            var cont = true;

            var count = 1;

            Console.WriteLine("Carter Media and Production Group Presents:\n");
            Thread.Sleep(2000);
            Console.WriteLine("A Conversation Between Ron Swanson and Ye:\n");
            Thread.Sleep(2000);

            while (cont)
            {
                Console.WriteLine($"Act 1 - Scene {count}");
                Thread.Sleep(2000);

                for (int i = 0; i < 5; i++)
                {
                    var kanyeResponse = client.GetStringAsync(kanyeURL).Result;

                    var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

                    Console.WriteLine($"Ye:      {kanyeQuote}\n");
                    Thread.Sleep(3500);

                    var ronResponse = client.GetStringAsync(ronURL).Result;

                    var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

                    Console.WriteLine($"Ron:     {ronQuote}\n");
                    Thread.Sleep(3500);
                }

                count++;

                Console.WriteLine("Shall we continue? (y/n)");
                var hold = Console.ReadLine();
                if (hold == "n" || hold == "no")
                {
                    cont = false;
                }
                Console.WriteLine(" ");
            }
        }
    }
}
