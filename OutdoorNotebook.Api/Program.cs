using Microsoft.OpenApi;
using OutdoorNotebook.Core;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<EventStorageServiceAsync>();
builder.Services.AddSingleton<FakeWeatherService>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "OutdoorNotebook API",
        Description = "API of OutdoorNotebook",
    });
});
var app = builder.Build();
var eventService = new EventService();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello World!");
app.MapGet("/weather", eventService.GetWeather);
app.MapGet("/events", eventService.ApiEventsDefault);
app.MapGet("/events/upcoming", eventService.ApiEventsUpcoming);

app.MapGet("/events/filter/place/{place}", (string place) => eventService.ApiEventsFilterPlace(place));
app.MapGet("/events/filter/difficulty/{difficulty}",
    (string difficulty) => eventService.ApiEventsFilterDifficulty(difficulty));

app.MapGet("/events/{id}", (int id) => eventService.ApiEventsFilterId(id));

app.MapGet("/async/events", async (EventStorageServiceAsync storage) =>
{
    var events = await storage.LoadEventsAsync();
    return Results.Ok(events);
});
app.MapGet("/async/events/weather", async (
    EventStorageServiceAsync storage,
    FakeWeatherService weatherService,
    CancellationToken cancellationToken) =>
{
    var events = await storage.LoadEventsAsync();
    var tasks = events.Select(async outdoorEvent =>
    {
        var weather = await weatherService.GetWeatherAsync(
            outdoorEvent.Place,
            cancellationToken
        );
        return new
        {
            outdoorEvent.Name,
            outdoorEvent.Place,
            Weather = weather.Summary,
            weather.TemperatureCelsius
        };
    });
    var result = await Task.WhenAll(tasks);
    return Results.Ok(result);
});


app.MapControllers();
app.Run();