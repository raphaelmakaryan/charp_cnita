using OutdoorNotebook.Core;


var weatherService = new FakeWeatherService();
var storage = new EventStorageServiceAsync();
var events = await storage.LoadEventsAsync();
foreach (var outdoorEvent in events)
{
    var weatherTasks = events
        .Select(e => weatherService.GetWeatherAsync(e.Place))
        .ToList();
    try
    {
        var weatherResults = await Task.WhenAll(weatherTasks);
        foreach (var weather in weatherResults)
        {
            Console.WriteLine(
                $"{weather.Location} — {weather.Summary} — {weather.TemperatureCelsius}°C"
            );
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Au moins une récupération météo a échoué : {ex.Message}");
    }
}