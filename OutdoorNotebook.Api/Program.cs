using OutdoorNotebook.Console.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
EventService eventService = new EventService();

app.MapGet("/", () => "Hello World!");
app.MapGet("/events", () => eventService.apiEventsDefault());
app.MapGet("/events/upcoming", () => eventService.apiEventsUpcoming());

app.Run();