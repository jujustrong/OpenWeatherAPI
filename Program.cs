using System;
using System.Text.Json.Nodes;
using System.Threading.Channels;
using Newtonsoft.Json.Linq;
using OpenWeatherMap;

Console.Write("Would you like to use the weather app? (y/n) ");
if (Console.ReadLine().ToLower() == "y") { WeatherApp.GetWeather(); }






