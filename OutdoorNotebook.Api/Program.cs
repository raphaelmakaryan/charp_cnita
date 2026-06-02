using OutdoorNotebook.Core;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var eventService = new EventService();

app.MapGet("/", () => "Hello World!");
app.MapGet("/events", eventService.ApiEventsDefault);
app.MapGet("/events/upcoming", eventService.ApiEventsUpcoming);
app.MapGet("/events/filter/place",
    () => "Veuillez spécifier un lieu pour filtrer les événements. Exemple : /events/filter/place/Paris");
app.MapGet("/events/filter/place/{place}", (string place) => eventService.ApiEventsFilterPlace(place));

app.Run();