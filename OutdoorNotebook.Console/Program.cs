// See https://aka.ms/new-console-template for more information

using OutdoorNotebook.Console.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

EventService eventService = new EventService();
Tools tools = new Tools();

EventStorageService eventStorageService = new EventStorageService();
Collection<OutdoorEvents> data = eventStorageService.LoadJson();

foreach (var outdoorEventse in eventService.upComingRelease(data))
{
    Console.WriteLine(outdoorEventse.DisplayData(outdoorEventse));
}

Console.WriteLine(tools.separation());
foreach (var outdoorEventse in eventService.fullReleases(data))
{
    Console.WriteLine(outdoorEventse.DisplayData(outdoorEventse));
}

Console.WriteLine(tools.separation());
foreach (var outdoorEventse in eventService.releasesStillAvailable(data))
{
    Console.WriteLine(outdoorEventse.DisplayData(outdoorEventse));
}

Console.WriteLine(tools.separation());