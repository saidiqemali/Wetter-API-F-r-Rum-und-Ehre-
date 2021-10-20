using System;
using System.Net.Http;

namespace Wetter_API__Für_Rum_und_Ehre_
{
    class Program
    {
        static void Main(string[] args)
        {
            //api.openweathermap.org/data/2.5/weather?q={city name}&appid={API key}
            //14ef7fc4abca59f2800df70ab9c334f6

            HttpClient httpClient = new HttpClient();

            string requestUri = "https://api.openweathermap.org/data/2.5/weather?q=dortmund&appid=14ef7fc4abca59f2800df70ab9c334f6&units=metric";

            HttpResponseMessage httpResponse = httpClient.GetAsync(requestUri).Result;

            string response = httpResponse.Content.ReadAsStringAsync().Result;
            Console.WriteLine(response);

            Console.ReadKey();
        }
    }
}
