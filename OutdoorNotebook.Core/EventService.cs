using System.Collections.ObjectModel;

namespace OutdoorNotebook.Core;

public class EventService
{
    /**
     * Fonction pour ressortir les sorties qui sont futures
     */
    public Collection<OutdoorEvents> UpComingRelease(Collection<OutdoorEvents> allEvents)
    {
        Collection<OutdoorEvents> response = new Collection<OutdoorEvents>();
        var sortieAVenir = from events in allEvents where events.Date1 >= DateTime.Today select events;
        foreach (var events in sortieAVenir)
        {
            response.Add(events);
        }

        return response;
    }

    /**
     * Fonction pour ressortir les sorties qui sont remplies
     */
    public Collection<OutdoorEvents> FullReleases(Collection<OutdoorEvents> allEvents)
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

    /**
     * Fonction pour ressortir les sorties qui sont disponibles
     */
    public Collection<OutdoorEvents> ReleasesStillAvailable(Collection<OutdoorEvents> allEvents)
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

    /**
     * Fonction pour créer des datas par défaut
     */
    public Collection<OutdoorEvents> CreateDefaultData()
    {
        return
        [
            new OutdoorEvents("Randonnée au Parmelan", DateTime.Today.AddDays(-1), "Annecy", 12, 3, null),
            new OutdoorEvents("Sortie vélo autour du lac", DateTime.Today.AddDays(+2), "Annecy", 8, 8, null),
            new OutdoorEvents("Kayak", DateTime.Today.AddDays(+10), "Cran-Gevrier", 20, 5, null),
            new OutdoorEvents("Jogging", DateTime.Today.AddDays(+1), "Annecy", 12, 12, null),
            new OutdoorEvents("Canoe", DateTime.Today.AddDays(+5), "Annecy", 12, 0, null)
        ];
    }

    /**
     * Fonction pour faire une vérification d'une sortie
     */
    public Boolean VerificationEvent(Collection<OutdoorEvents> events)
    {
        bool result = true;
        foreach (var data in events)
        {
            result = !(String.IsNullOrEmpty(data.Name1) && String.IsNullOrEmpty(data.Lieu1)) &&
                     data.MaxParticipants1 > 0 &&
                     data.ParticipantsActual1 >= 0 && data.ParticipantsActual1 <= data.MaxParticipants1;
        }

        return result;
    }

    /**
     * Fonction pour la route API "events" par défaut
     */
    public Collection<OutdoorEvents> ApiEventsDefault()
    {
        return CreateDefaultData();
    }

    /**
     * Fonction pour la route API "events/upcoming"
     */
    public Collection<OutdoorEvents> ApiEventsUpcoming()
    {
        return UpComingRelease(CreateDefaultData());
    }
}