using Refit;

namespace UnoApp13.Services.Endpoints;
[Headers("Content-Type: application/json")]
public interface IApiClient
{
    [Get("/api/weatherforecast")]
    Task<ApiResponse<IImmutableList<WeatherForecast>>> GetWeather(CancellationToken cancellationToken = default);
}
