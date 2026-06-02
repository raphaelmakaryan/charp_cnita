using System.Collections.ObjectModel;
using System.Globalization;

namespace OutdoorNotebook.Core;

public class EventService
{
    readonly EventStorageService _eventStorageService = new EventStorageService();

    /**
     * Fonction pour ressortir les sorties qui sont futures
     */
    public Collection<OutdoorEvents> UpComingRelease(Collection<OutdoorEvents> allEvents)
    {
        Collection<OutdoorEvents> response = new Collection<OutdoorEvents>();
        var sortieAVenir = from events in allEvents where events.Date >= DateTime.Today select events;
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
            where events.IsFull(events.ParticipantsActual, events.MaxParticipants)
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
            where !events.IsFull(events.ParticipantsActual, events.MaxParticipants) && events.Date >= DateTime.Today
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
            new OutdoorEvents("Randonnée au Parmelan", DateTime.Today.AddDays(-1), "Annecy", 12, 3, null,
                EventsDifficulty.Difficile),
            new OutdoorEvents("Sortie vélo autour du lac", DateTime.Today.AddDays(+2), "Annecy", 8, 8, null,
                EventsDifficulty.Facile),
            new OutdoorEvents("Kayak", DateTime.Today.AddDays(+10), "Cran-Gevrier", 20, 5, null,
                EventsDifficulty.Normal),
            new OutdoorEvents("Jogging", DateTime.Today.AddDays(+1), "Annecy", 12, 12, null, EventsDifficulty.Facile),
            new OutdoorEvents("Canoe", DateTime.Today.AddDays(+5), "Annecy", 12, 0, null, EventsDifficulty.Normal)
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
            result = !(String.IsNullOrEmpty(data.Name) && String.IsNullOrEmpty(data.Place)) &&
                     data.MaxParticipants > 0 &&
                     data.ParticipantsActual >= 0 && data.ParticipantsActual <= data.MaxParticipants;
        }

        return result;
    }

    /**
     * Fonction pour la route API "events" par défaut
     */
    public Collection<OutdoorEvents> ApiEventsDefault()
    {
        return _eventStorageService.LoadJson();
    }

    /**
     * Fonction pour la route API "events/upcoming"
     */
    public Collection<OutdoorEvents> ApiEventsUpcoming()
    {
        return UpComingRelease(_eventStorageService.LoadJson());
    }

    /**
     * Fonction pour la route API "/events/filter/place/{place}", filtrage par lieu
     */
    public Collection<OutdoorEvents> ApiEventsFilterPlace(String place)
    {
        Collection<OutdoorEvents> response = new Collection<OutdoorEvents>();
        var sortieWithPlace = from events in _eventStorageService.LoadJson()
            where events.Place == place
            select events;
        foreach (var events in sortieWithPlace)
        {
            response.Add(events);
        }

        return response;
    }

    public Collection<OutdoorEvents> ApiEventsFilterDifficulty(String difficultyString)
    {
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        Collection<OutdoorEvents> response = new Collection<OutdoorEvents>();
        if (Enum.TryParse(ti.ToTitleCase(difficultyString), out EventsDifficulty difficulty))
        {
            var sortieWithDifficulty = from events in _eventStorageService.LoadJson()
                where events.Difficulty == difficulty
                select events;
            foreach (var events in sortieWithDifficulty)
            {
                response.Add(events);
            }
        }

        return response;
    }
}