using dive_deep.Models;

namespace dive_deep.Services
{
    public interface IWeatherService
    {
        Task<DiveConditionsViewModel> GetConditions(string cityName);
    }
}
