using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using dive_deep.Models;
using System.Transactions;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using dive_deep.Services;

public class WeatherController : Controller
{
    private readonly IWeatherService weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        this.weatherService = weatherService;
    }

    [HttpPost]
    public async Task<IActionResult> Index(string name)
    {
        DiveConditionsViewModel model = await weatherService.GetConditions(name);
        return View(model);
    }

    [HttpGet]
    public ViewResult Index()
    {
        return View();
    }
}