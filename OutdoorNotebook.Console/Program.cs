using OutdoorNotebook.Core;

async Task<string> GetWeatherLineAsync(
    OutdoorEvents outdoorEvent,
    FakeWeatherService weatherService)
{
    try
    {
        var weather = await weatherService.GetWeatherAsync(outdoorEvent.Place);

        return $"{outdoorEvent.Name} — {weather.Location} — {weather.Summary} — {weather.TemperatureCelsius} °C";
    }
    catch
    {
        return $"{outdoorEvent.Name} — {outdoorEvent.Place} — météo indisponible";
    }
}

var weatherService = new FakeWeatherService();
var storage = new EventStorageServiceAsync();
var events = await storage.LoadEventsAsync();
foreach (var outdoorEvent in events)
{
    var weatherLineTasks = events
        .Select(e => GetWeatherLineAsync(e, weatherService))
        .ToList();
    var weatherLines = await Task.WhenAll(weatherLineTasks);
    foreach (var line in weatherLines)
    {
        Console.WriteLine(line);
    }
}