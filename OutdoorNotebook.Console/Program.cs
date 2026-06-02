using OutdoorNotebook.Core;

Tools tools = new Tools();
var weatherService = new FakeWeatherService();
var storage = new EventStorageServiceAsync();
var events = await storage.LoadEventsAsync();
foreach (var outdoorEvent in events)
{
    var weather = await weatherService.GetWeatherAsync(outdoorEvent.Place);
    Console.WriteLine(OutdoorEvents.DisplayData(outdoorEvent));
    Console.WriteLine(tools.Separation());
    Console.WriteLine($"{outdoorEvent.Name} — {weather.Location} — {weather.Summary} — {weather.TemperatureCelsius}°C");
}
Console.WriteLine(tools.Separation());