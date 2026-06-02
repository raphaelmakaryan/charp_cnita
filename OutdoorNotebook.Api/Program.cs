using Microsoft.OpenApi;
using OutdoorNotebook.Core;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
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
    // http://localhost:<port>/swagger/index.html
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

app.MapGet("/event/{id}", (int id) => eventService.ApiEventsFilterId(id));


app.MapControllers();
app.Run();