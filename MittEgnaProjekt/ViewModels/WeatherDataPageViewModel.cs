using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MittEgnaProjekt.ViewModels
{
    internal class WeatherDataPageViewModel
    {
        public Models.WeatherData TheWeatherData { get; set; }
        public WeatherDataPageViewModel()
        {
            var task = Task.Run(() => GetWeatherDataAsync());
            task.Wait();
            TheWeatherData = task.Result;
        }
        public static async Task<Models.WeatherData> GetWeatherDataAsync()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://api.api-ninjas.com/v1/weather?city=Tystberga");

            client.DefaultRequestHeaders.Add("X-Api-Key", "0QjxIyzYhmgDi64iWj1osA==n9inttH4h9CR9scw");

            Models.WeatherData weatherData= null;

            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                weatherData = JsonSerializer.Deserialize<Models.WeatherData>(responseString);   
            }
            return weatherData;
        }
    }
}
