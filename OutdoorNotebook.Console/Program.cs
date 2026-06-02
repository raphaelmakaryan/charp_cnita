using OutdoorNotebook.Core;


var weatherService = new FakeWeatherService();
var storage = new EventStorageServiceAsync();
var events = await storage.LoadEventsAsync();
foreach (var outdoorEvent in events)
{
    using var cts = new CancellationTokenSource();
    cts.CancelAfter(1000);
    try
    {
        var weather = await weatherService.GetWeatherAsync("Annecy", cts.Token);
        Console.WriteLine(
            $"{weather.Location} — {weather.Summary} — {weather.TemperatureCelsius}°C"
        );
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine("La récupération météo a été annulée.");
    }
}