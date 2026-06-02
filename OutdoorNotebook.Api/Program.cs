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

app.MapGet("/events/filter/difficulty",
    () => "Veuillez spécifier une difficulté pour filtrer les événements. Exemple : /events/filter/difficulty/facile");
app.MapGet("/events/filter/difficulty/{difficulty}",
    (string difficulty) => eventService.ApiEventsFilterDifficulty(difficulty));

app.MapGet("/event/{id}", (int id) => eventService.ApiEventsFilterId(id));

app.Run();