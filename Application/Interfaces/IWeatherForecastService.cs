using MaisUmaRedeSocial.Domain.Models.WeatherForecast;

namespace MaisUmaRedeSocial.Application.Services
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> GetWeatherForecasts();
    }
}
