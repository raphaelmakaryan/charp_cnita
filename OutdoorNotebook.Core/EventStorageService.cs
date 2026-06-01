using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.Json;

namespace OutdoorNotebook.Core;

public class EventStorageService
{
    private readonly string _fileName = "data/events.json";

    /**
     * Fonction pour afficher dans la console la lecture du JSON
     */
    public void ReadJson(JsonElement dataJson)
    {
        System.Console.WriteLine(dataJson);
    }

    /**
     * Fonction pour charger le JSON, le désérialiser ainsi que le retourner dans une collection
     */
    public Collection<OutdoorEvents> LoadJson()
    {
        Collection<OutdoorEvents> allEvents = new Collection<OutdoorEvents>();
        // récupérer tout le fichier
        string data = File.ReadAllText(_fileName);
        // je le parse en json
        using JsonDocument doc = JsonDocument.Parse(data);
        // je recupere toute les data
        JsonElement root = doc.RootElement;
        // je récupère la propriete "events"
        JsonElement allData = root.GetProperty("events");
        //readJson(allData);

        foreach (var events in allData.EnumerateArray())
        {
            string dateString = events.GetProperty("Date").GetString() ??
                                DateTime.Today.ToString(CultureInfo.CurrentCulture);
            DateTime date = DateTime.TryParse(dateString, out DateTime parsedDate)
                ? parsedDate
                : DateTime.MinValue;
            allEvents.Add(new OutdoorEvents(events.GetProperty("Name").GetString() ?? "Pas de nom",
                date, events.GetProperty("Lieu").GetString() ?? "Pas de liey",
                events.GetProperty("MaxParticipants").GetInt32(),
                events.GetProperty("ParticipantsActual").GetInt32(),
                events.GetProperty("Description").GetString() ?? "Aucune description"));
        }

        return allEvents;
    }
}