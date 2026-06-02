namespace OutdoorNotebook.Core;

public class WeatherInfo
{
    public string Location { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public int TemperatureCelsius { get; set; }
}