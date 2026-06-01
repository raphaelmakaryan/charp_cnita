using OutdoorNotebook.Core;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
EventService eventService = new EventService();

app.MapGet("/", () => "Hello World!");
app.MapGet("/events", () => eventService.ApiEventsDefault());
app.MapGet("/events/upcoming", () => eventService.ApiEventsUpcoming());

app.Run();