namespace OutdoorNotebook.Core;

public class FakeWeatherService
{
    public async Task<WeatherInfo> GetWeatherAsync(string location)
    {
        await Task.Delay(1000);
        return new WeatherInfo
        {
            Location = location,
            Summary = "Ensoleillé",
            TemperatureCelsius = 18
        };
    }
}