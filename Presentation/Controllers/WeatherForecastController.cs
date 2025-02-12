using MaisUmaRedeSocial.Application.Services;
using MaisUmaRedeSocial.Domain.Models.WeatherForecast;
using Microsoft.AspNetCore.Mvc;

namespace MaisUmaRedeSocial.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherForecastController(IWeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return _weatherForecastService.GetWeatherForecasts();
    }
}

