namespace OutdoorNotebook.Core;

public class FakeWeatherService
{
    public async Task<WeatherInfo> GetWeatherAsync(
        string location,
        CancellationToken cancellationToken)
    {
        await Task.Delay(3000, cancellationToken);
        if (location.Contains("Erreur", StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                $"Impossible de récupérer la météo pour {location}"
            );
        }

        return new WeatherInfo

        {
            Location = location,
            Summary = "Nuageux",
            TemperatureCelsius = 12
        };
    }
}