using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using northwind_blazor.Application.WeatherForecasts.Queries;
using northwind_blazor.WebUI.Shared.WeatherForecasts;

namespace northwind_blazor.WebUI.Server.Controllers
{
    [Authorize]
    public class WeatherForecastController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IList<WeatherForecast>> Get()
        {
            return await Mediator.Send(new GetWeatherForecastsQuery());
        }
    }
}