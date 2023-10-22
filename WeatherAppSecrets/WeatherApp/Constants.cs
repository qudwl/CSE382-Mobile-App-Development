using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace WeatherApp {
    public static class Constants {
        // Use https, not http
        public static string OpenWeatherMapEndpoint = "https://api.openweathermap.org/data/2.5/weather";
        public static string GetOpenWeatherMapAPIKey() {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            IConfiguration configuration = configurationBuilder.AddUserSecrets<App>().Build();
            string key = configuration["APIKEY"];
            return key;
        }
    }
}
