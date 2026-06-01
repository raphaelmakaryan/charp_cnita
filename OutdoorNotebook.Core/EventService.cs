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
        IEnumerable<OutdoorEvents> sortieTrié = allEvents.OrderBy(events => events.Date1);
        foreach (var events in sortieTrié)
        {
            response.Add(events);
        }

        return response;
    }
}