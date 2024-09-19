using System;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;

namespace OpenWeatherMap;

public class WeatherApp
{


    public static void GetWeather()
    {
        var i = true;
        while (i)
        {
            var client = new HttpClient();
            var appsettingsText = File.ReadAllText("appsettings.json");         //this is a STRING of JSON. We need a piece of it.
            var apiKey = JObject.Parse(appsettingsText)["key"].ToString();          //parsing the json object to a string by the key.

            Console.WriteLine("Enter your 5-digit ZIP code: ");
            var userZip = Console.ReadLine();
            var zip = int.TryParse(userZip, out var zipcode);
            
            
            while (!zip || userZip.Length != 5)                          //Error handling for invalid zip input.
            {
                Console.WriteLine("Error: Please enter a valid ZIP code: ");
                zip = int.TryParse(Console.ReadLine(), out zipcode);
            }
            
            var url = $"https://api.openweathermap.org/data/2.5/weather?zip={zipcode}&appid={apiKey}&units=imperial";
            
            try
            {
                //using TRY in case user does not enter a zipcode in located in the API
                var response = client.GetStringAsync(url).Result;
                var temperature = double.Parse(JObject.Parse(response)["main"]["temp"].ToString());
                var feel = double.Parse(JObject.Parse(response)["main"]["feels_like"].ToString());

                Console.WriteLine($"Current Temperature  is {temperature}°F and it feels like {feel}°F");
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }

            Console.Write("Exit? (y/n): ");
            var input = Console.ReadLine();
            Console.Clear();
            if (input.ToLower() != "n")
            {
                i = false;
            }
        }

    }
    
    
}




