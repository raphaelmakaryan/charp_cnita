using OutdoorNotebook.Core;


var weatherService = new FakeWeatherService();
var start = DateTime.Now;
var storage = new EventStorageServiceAsync();
var events = await storage.LoadEventsAsync();
foreach (var outdoorEvent in events)
{
    var weatherTasks = events
        .Select(e => weatherService.GetWeatherAsync(e.Place))
        .ToList();
    var weatherResults = await Task.WhenAll(weatherTasks);
    foreach (var weather in weatherResults)
    {
        Console.WriteLine(
            $"{weather.Location} — {weather.Summary} — {weather.TemperatureCelsius}°C"
        );
    }
}
var duration = DateTime.Now - start;
Console.WriteLine($"Durée : {duration.TotalSeconds:F2} secondes");