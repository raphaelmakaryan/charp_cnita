namespace OutdoorNotebook.Core;

public class FakeWeatherService
{
    public async Task<WeatherInfo> GetWeatherAsync(string location)
    {
        await Task.Delay(1000);
        if (location.Contains("Erreur", StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                $"Impossible de récupérer la météo pour {location}"
            );
        }

        return new WeatherInfo
        {
            Location = location,
            Summary = "Ensoleillé",
            TemperatureCelsius = 18
        };
    }
}