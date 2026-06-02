using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.Json;

namespace OutdoorNotebook.Core;

public class EventStorageService
{
    private const string RelativeFileName = "data/events.json";

    /**
     * Fonction pour afficher dans la console la lecture du JSON
     */
    public void ReadJson(JsonElement dataJson)
    {
        Console.WriteLine(dataJson);
    }

    /**
     * Fonction pour aller chercher le JSON
     */
    private static string ResolveJsonPath()
    {
        string[] searchRoots = [AppContext.BaseDirectory, Directory.GetCurrentDirectory()];

        foreach (string root in searchRoots)
        {
            DirectoryInfo? currentDirectory = new DirectoryInfo(root);

            while (currentDirectory is not null)
            {
                string candidate = Path.Combine(currentDirectory.FullName, RelativeFileName);
                if (File.Exists(candidate))
                {
                    return candidate;
                }

                currentDirectory = currentDirectory.Parent;
            }
        }

        throw new FileNotFoundException($"Impossible de trouver '{RelativeFileName}'.", RelativeFileName);
    }

    /**
     * Fonction pour charger le JSON, le désérialiser ainsi que le retourner dans une collection
     */
    public Collection<OutdoorEvents> LoadJson()
    {
        Collection<OutdoorEvents> allEvents = new Collection<OutdoorEvents>();
        // récupérer tout le fichier
        string data = File.ReadAllText(ResolveJsonPath());
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
            string difficultyString = events.GetProperty("Difficulty").GetString() ?? nameof(EventsDifficulty.Normal);
            EventsDifficulty difficulty = Enum.TryParse(difficultyString, out EventsDifficulty parsedDifficulty)
                ? parsedDifficulty
                : EventsDifficulty.Normal;
            allEvents.Add(new OutdoorEvents(events.GetProperty("Id").GetInt32(),
                events.GetProperty("Name").GetString() ?? "Pas de nom",
                date, events.GetProperty("Place").GetString() ?? "Pas de lieu",
                events.GetProperty("MaxParticipants").GetInt32(),
                events.GetProperty("ParticipantsActual").GetInt32(),
                events.GetProperty("Description").GetString() ?? "Aucune description", difficulty,
                events.GetProperty("Duration").GetInt32(),
                events.GetProperty("MeetingPlace").GetString() ?? "Aucun lieu de rendez-vous"
            ));
        }

        return allEvents;
    }
}