using dive_deep.Models;
using dive_deep.Models.API;
using dive_deep.Models.API.Response;

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


            CityResponse? cityResponse = await geoHttpClient.GetFromJsonAsync<CityResponse>($"search?name={cityName}&count=10&language=en&format=json"); 
            if (cityResponse == null || cityResponse.Results == null)
            {
                throw new Exception("City response is null");
            }
            City city = cityResponse.Results[0];

            WeatherResponse? weatherResponse = await weatherHttpClient.GetFromJsonAsync<WeatherResponse>($"forecast?latitude={city.Latitude}&longitude={city.Longitude}&hourly=wind_speed_10m,weather_code,precipitation");
            if (weatherResponse == null || weatherResponse.Hourly == null)
            {
                throw new Exception("Weather response is null");
            }
            Weather weather = weatherResponse.Hourly;

            MarineResponse? marineResponse = await marineHttpClient.GetFromJsonAsync<MarineResponse>($"marine?latitude={city.Latitude}&longitude={city.Longitude}&hourly=wave_height");
            if (marineResponse == null || marineResponse.Hourly == null || marineResponse.Hourly.Wave_Height == null)
            {
                throw new Exception("Marine response is null");
            }
            Marine marine = marineResponse.Hourly;

            double windSpeed = weather.Wind_Speed_10M[0];
            double waveHeight = marine.Wave_Height[0] ?? 0.0;
            double precipitation = weather.Precipitation[0];
            int weatherCode = weather.Weather_Code[0];

            return new DiveConditionsViewModel(windSpeed, waveHeight, precipitation, weatherCode);
        }
    }
}
