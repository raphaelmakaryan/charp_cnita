// See https://aka.ms/new-console-template for more information

using System.Collections.ObjectModel;
using OutdoorNotebook.Core;

EventService eventService = new EventService();
Tools tools = new Tools();

EventStorageService eventStorageService = new EventStorageService();
Collection<OutdoorEvents> data = eventStorageService.LoadJson();

foreach (var events in data)
{
    Console.WriteLine(events.DisplayData(events));
}

Console.WriteLine(Tools.Separation());
foreach (var outdoorEvents in eventService.UpComingRelease(data))
{
    Console.WriteLine(outdoorEvents.DisplayData(outdoorEvents));
}

Console.WriteLine(Tools.Separation());
foreach (var outdoorEvents in eventService.FullReleases(data))
{
    Console.WriteLine(outdoorEvents.DisplayData(outdoorEvents));
}

Console.WriteLine(Tools.Separation());