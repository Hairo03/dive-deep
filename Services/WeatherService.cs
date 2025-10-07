using dive_deep.Models;

namespace dive_deep.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public WeatherService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<DiveConditionsViewModel> GetConditions(string cityName)
        {
            using var weatherHttpClient = httpClientFactory.CreateClient("OpenMeteoWeather");
            using var geoHttpClient = httpClientFactory.CreateClient("OpenMeteoGeo");
            using var marineHttpClient = httpClientFactory.CreateClient("OpenMeteoMarine");

            var name = await geoHttpClient.GetAsync($"search?name={ cityName }&count=10&language=en&format=json");
            CityResponse city = await name.Content.ReadFromJsonAsync<CityResponse>();

            WeatherResponse weather = await weatherHttpClient.GetFromJsonAsync<WeatherResponse>($"forecast?latitude={city.Latitude}&longitude={city.Longitude}&hourly=wind_speed_10m,weather_code,precipitation");
            MarineResponse marine = await marineHttpClient.GetFromJsonAsync<MarineResponse>($"marine?latitude={city.Latitude}&longitude={city.Longitude}&hourly=wave_height");

            return new DiveConditionsViewModel(weather.Hourly[0].WindSpeed10M, marine.WaveHeight, weather.Hourly[0].Precipation, weather.Hourly[0].WeatherCode);
        }
    }
}
