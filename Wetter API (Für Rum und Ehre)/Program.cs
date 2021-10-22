using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace Wetter_API__Für_Rum_und_Ehre_
{
    class Program
    {
        static void Main(string[] args)
        {
            //api.openweathermap.org/data/2.5/weather?q={city name}&appid={API key}                                                                                  // API zugreifen
            //14ef7fc4abca59f2800df70ab9c334f6                                                                                                                       // API Passwort/Key (jede user kann eine eigene API Key erstellen)


            Console.WriteLine(" Stadt eintragen");                                                                                                                   // Ausgabe : beliebige Stadt eingeben 
            string city = Console.ReadLine();                                                                                                                        // Die Stadt wo eingegeben wird = String city


            HttpClient httpClient = new HttpClient();                                                                                                                // neues client erstellen

            string requestUri = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=14ef7fc4abca59f2800df70ab9c334f6&units=metric";                // "Anfrage" zum API zugreifen

            HttpResponseMessage httpResponse = httpClient.GetAsync(requestUri).Result;                                                                               // Antwort
            string response = httpResponse.Content.ReadAsStringAsync().Result;                                                                                       // Antwort

            weatherMapResponse weatherMapResponse = JsonConvert.DeserializeObject<weatherMapResponse>(response);                                                     // Ergebnis von json in "c#" umwandeln



            Console.WriteLine(" - In " + city + " ist es " + weatherMapResponse.main.temp + " Grad"); // "temp" value ausgeben
            Console.WriteLine("\n"); // Leerzeile
            Console.WriteLine(" - Die minimale Temperatur in " + city + " betraegt " + weatherMapResponse.main.temp_min + " Grad"); // "temp_min" value ausgeben
            Console.WriteLine(" - Die maximale Temperatur in " + city + " betraegt " + weatherMapResponse.main.temp_max + " Grad"); // "temp_max" value ausgeben
            Console.WriteLine("\n"); // Leerzeile

            Console.WriteLine(" - Die Feuchtigkeit in " + city + " betraegt " + weatherMapResponse.main.humidity); // "humidity" value ausgeben
            Console.WriteLine("\n"); // Leerzeile

            Console.WriteLine(" Standort Beschreibung");
            Console.WriteLine("-  Die Stadt " + city + " befindet sich in '" + weatherMapResponse.sys.country + "'"); // "country" value ausgeben
            Console.WriteLine("\n"); // Leerzeile

            Console.WriteLine(" - Die Koordinaten von " + city + " sind" + "\n" + " - Breitengrad = " + weatherMapResponse.coord.lat + "\n" + " - Längengrad = " + weatherMapResponse.coord.lon); // "lat" value und "lon" value ausgeben
            Console.WriteLine("\n"); // Leerzeile



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

