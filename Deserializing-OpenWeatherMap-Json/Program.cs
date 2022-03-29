using Deserializing_OpenWeatherMap_Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace OpenWeatherMap_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var jsonRootObject = new Json_Root();
            
            Console.Write("Please enter your API Key: ");
            var api_Key = Console.ReadLine();

            Console.WriteLine();
            
            Console.Write("Please enter the city name: ");
            var city_name = Console.ReadLine();
            
            Console.WriteLine();

            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&units=imperial&appid={api_Key}";
            var response = client.GetStringAsync(weatherURL).Result;
            var weatherJson = JObject.Parse(response).GetValue("weather").ToString();
           
            jsonRootObject.WeatherList = JsonConvert.DeserializeObject<List<Weather>>(weatherJson);
            jsonRootObject.WeatherList.ForEach(x => PrintWeather(x));


        }
        
        static void PrintWeather(Weather w)
        {
            Console.WriteLine($"Description: {w.description}");
            Console.WriteLine(w.icon);
            Console.WriteLine(w.id);
            Console.WriteLine(w.main);
        }
    }
}
