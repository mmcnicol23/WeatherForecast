using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WeatherForecast;
class Program
{
    static void Main(string[] args)
    {
        var client = new HttpClient();
        var city = "Flint";

        var weatherURL =
            $"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={key}&units=imperial";
        var response = client.GetStringAsync(weatherURL).Result;

        JObject formattedResponse = JObject.Parse(response);
        var temp = formattedResponse["list"][0]["main"]["temp"];
        Console.WriteLine($"The current temperature for {city} is: {temp} F");
    }
}
