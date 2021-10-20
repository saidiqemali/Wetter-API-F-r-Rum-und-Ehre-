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

            HttpResponseMessage httpResponse = httpClient.GetAsync().Result;
        }
    }
}
