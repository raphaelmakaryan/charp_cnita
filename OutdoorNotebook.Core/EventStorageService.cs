using System.Collections.ObjectModel;
using System.Text.Json;


namespace OutdoorNotebook.Console.Models;

public class EventStorageService
{
    protected string fileName = "data/events.json";

    public void readJson(JsonElement dataJson)
    {
        System.Console.WriteLine(dataJson);
    }

    public Collection<OutdoorEvents> LoadJson()
    {
        Collection<OutdoorEvents> allEvents = new Collection<OutdoorEvents>();
        // récuperer tout le fichier
        string data = File.ReadAllText(fileName);
        // je le parse en json
        using JsonDocument doc = JsonDocument.Parse(data);
        // je recupere toute les data
        JsonElement root = doc.RootElement;
        // je récuperer la propriete events
        JsonElement allData = root.GetProperty("events");
        //readJson(allData);

        foreach (var events in allData.EnumerateArray())
        {
            allEvents.Add(new OutdoorEvents(events.GetProperty("Name").ToString(),
                DateTime.Parse(events.GetProperty("Date").ToString()), events.GetProperty("Lieu").ToString(),
                events.GetProperty("MaxParticipants").GetInt32(),
                events.GetProperty("ParticipantsActual").GetInt32(),
                events.GetProperty("Description").ToString()));
        }

        return allEvents;
    }
}