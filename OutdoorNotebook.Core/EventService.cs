using System.Collections.ObjectModel;
using Microsoft.VisualBasic;

namespace OutdoorNotebook.Console.Models;

public class EventService
{
    public Collection<OutdoorEvents> upComingRelease(Collection<OutdoorEvents> allEvents)
    {
        Collection<OutdoorEvents> response = new Collection<OutdoorEvents>();
        var sortieAVenir = from events in allEvents where events.Date1 >= DateTime.Today select events;
        foreach (var events in sortieAVenir)
        {
            response.Add(events);
        }

        return response;
    }

    public Collection<OutdoorEvents> fullReleases(Collection<OutdoorEvents> allEvents)
    {
        Collection<OutdoorEvents> response = new Collection<OutdoorEvents>();
        var sortieComplete = from events in allEvents
            where events.IsFull(events.ParticipantsActual1, events.MaxParticipants1)
            select events;
        foreach (var events in sortieComplete)
        {
            response.Add(events);
        }

        return response;
    }

    public Collection<OutdoorEvents> releasesStillAvailable(Collection<OutdoorEvents> allEvents)
    {
        Collection<OutdoorEvents> response = new Collection<OutdoorEvents>();
        var sortieDispo = from events in allEvents
            where !events.IsFull(events.ParticipantsActual1, events.MaxParticipants1) && events.Date1 >= DateTime.Today
            select events;
        foreach (var events in sortieDispo)
        {
            response.Add(events);
        }

        return response;
    }

    public Collection<OutdoorEvents> CreateDefaultData()
    {
        return new Collection<OutdoorEvents>()
        {
            new OutdoorEvents("Randonnée au Parmelan", DateTime.Today.AddDays(-1), "Annecy", 12, 3, null),
            new OutdoorEvents("Sortie vélo autour du lac", DateTime.Today.AddDays(+2), "Annecy", 8, 8, null),
            new OutdoorEvents("Kayak", DateTime.Today.AddDays(+10), "Cran-Gevrier", 20, 5, null),
            new OutdoorEvents("Jogging", DateTime.Today.AddDays(+1), "Annecy", 12, 12, null),
            new OutdoorEvents("Canoe", DateTime.Today.AddDays(+5), "Annecy", 12, 0, "")
        };
    }
}