using OutdoorNotebook.Core;


var weatherService = new FakeWeatherService();
var storage = new EventStorageServiceAsync();
var events = await storage.LoadEventsAsync();
foreach (var outdoorEvent in events)
{
    try
    {
        var weather = await weatherService.GetWeatherAsync("ErreurVille");
        Console.WriteLine(weather.Summary);
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Erreur météo : {ex.Message}");
    }
}