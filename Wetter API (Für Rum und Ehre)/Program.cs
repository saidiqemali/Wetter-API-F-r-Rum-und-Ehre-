using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace Wetter_API__Für_Rum_und_Ehre_
{
    class Program
    {
        static void Main(string[] args)
        {
            //api.openweathermap.org/data/2.5/weather?q={city name}&appid={API key}
            //14ef7fc4abca59f2800df70ab9c334f6


            Console.WriteLine(" Stadt eintragen");
            string city = Console.ReadLine();


            HttpClient httpClient = new HttpClient();

            string requestUri = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=14ef7fc4abca59f2800df70ab9c334f6&units=metric";

            HttpResponseMessage httpResponse = httpClient.GetAsync(requestUri).Result;
            string response = httpResponse.Content.ReadAsStringAsync().Result;
            
            weatherMapResponse weatherMapResponse = JsonConvert.DeserializeObject<weatherMapResponse>(response);



            Console.WriteLine(" - In " + city + " ist es " + weatherMapResponse.main.temp + " Grad Celsius");
            Console.WriteLine("\n");
            Console.WriteLine(" - Die minimale Temperatur in " + city + " betraegt " + weatherMapResponse.main.temp_min + " Grad");
            Console.WriteLine(" - Die maximale Temperatur in " + city + " betraegt " + weatherMapResponse.main.temp_max + " Grad");
            Console.WriteLine("\n");
            Console.WriteLine(" - Die Feuchtigkeit in " + city + " betraegt " + weatherMapResponse.main.humidity);
            Console.WriteLine("\n");

            Console.WriteLine(" Standort Beschreibung");
            Console.WriteLine("-  Die Stadt " + city + " befindet sich in '" + weatherMapResponse.sys.country + "'");
            Console.WriteLine("\n");
            

            Console.WriteLine(" - Die Koordinaten von " + city + " sind" + "\n" + " - Breitengrad = " + weatherMapResponse.coord.lat + "\n" + " - Längengrad = " + weatherMapResponse.coord.lon);
            Console.WriteLine("\n");
     


            Console.ReadKey();
        }
    }

    class weatherMapResponse
    {
        public Main main;
        public Main coord;
        public Main sys;
    }

    class Main
    {
        public float temp;
        public float temp_max;
        public float temp_min;
        public float humidity;
        public float lon;
        public float lat;
        public string country;
        public string description;
    }
}
