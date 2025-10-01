using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using dive_deep.Models;

public class WeatherController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public WeatherController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index(double lat = 55.6761, double lon = 12.5683)
    {
        var client = _httpClientFactory.CreateClient();

        // 1) Weather API kald (vind, nedbør, etc.)
        string weatherUrl = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&hourly=temperature_2m,wind_speed_10m,precipitation,weather_code&timezone=auto";
        var weatherJson = await client.GetStringAsync(weatherUrl);
        var weatherDoc = JsonDocument.Parse(weatherJson);

        var weatherHourly = weatherDoc.RootElement.GetProperty("hourly");
        // Find index nærmest nu — her bare brug index 0 som eksempel
        int idx = 0;

        double wind = weatherHourly.GetProperty("wind_speed_10m")[idx].GetDouble();
        double rain = weatherHourly.GetProperty("precipitation")[idx].GetDouble();
        int weatherCode = weatherHourly.GetProperty("weather_code")[idx].GetInt32();
        double airTemp = weatherHourly.GetProperty("temperature_2m")[idx].GetDouble();

        // Simpel tordencheck via weather_code (eksempelværdier)
        bool thunder = (weatherCode == 95 || weatherCode == 96 || weatherCode == 99);

        // 2) Marine API kald (bølgehøjde)
        string marineUrl = $"https://marine-api.open-meteo.com/v1/marine?latitude={lat}&longitude={lon}&hourly=wave_height,sea_surface_temperature&timezone=auto";
        var marineJson = await client.GetStringAsync(marineUrl);
        var marineDoc = JsonDocument.Parse(marineJson);

        var marineHourly = marineDoc.RootElement.GetProperty("hourly");
        double waves = marineHourly.GetProperty("wave_height")[idx].GetDouble();

        // Saml i viewmodel
        var model = new DiveConditionsViewModel
        {
            WindSpeed = wind,
            Precipitation = rain,
            Thunder = thunder,
            WaveHeight = waves,
            // Vandtemperatur: du kunne hente “sea_surface_temperature” via marine API også,
            // hvis du tilføjer det som variabel i marine-URL (fx &hourly=wave_height,sea_surface_temperature).
        };

        // Vurdering (som før)
        bool suitable = true;
        var msgs = new List<string>();

        if (wind >= 8) { suitable = false; msgs.Add($"Vind for høj: {wind} m/s"); }
        if (waves >= 1.5) { suitable = false; msgs.Add($"For høje bølger: {waves} m"); }
        if (rain >= 2) { suitable = false; msgs.Add($"For meget regn: {rain} mm/t"); }
        if (thunder) { suitable = false; msgs.Add("⚠️ Risiko for torden – dykning frarådes"); }

        model.Suitable = suitable;
        model.Messages = msgs;

        // Dragtanbefaling – hvis du har vandtemperatur (her bruger vi lufttemperatur som placeholder)
        double tempForDragt = airTemp;
        if (tempForDragt > 24) model.SuitRecommendation = "Våddragt (3mm)";
        else if (tempForDragt >= 18) model.SuitRecommendation = "Våddragt (5mm)";
        else if (tempForDragt >= 10) model.SuitRecommendation = "Våddragt (7mm)";
        else model.SuitRecommendation = "Tørdragt";

        return View(model);
    }
}


