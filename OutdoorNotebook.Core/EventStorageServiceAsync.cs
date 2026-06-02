using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OutdoorNotebook.Core;

public class EventStorageServiceAsync
{
    private const string RelativeFileName = "data/events.json";

    /**
     * Enum pour la difficulté des événements, avec un JsonConverter pour les sérialiser/désérialiser en tant que string dans le JSON
     */
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EventsDifficulty
    {
        Facile,
        Normal,
        Difficile
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
    public async Task<List<OutdoorEvents>> LoadEventsAsync()
    {
        var json = await File.ReadAllTextAsync(ResolveJsonPath());
        using JsonDocument doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;
        JsonElement allData = root.GetProperty("events");
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        options.Converters.Add(new DateTimeConverter("MM-dd-yyyy"));
        options.Converters.Add(new JsonStringEnumConverter());
        return JsonSerializer.Deserialize<List<OutdoorEvents>>(allData.GetRawText(), options)
               ?? new List<OutdoorEvents>();
    }

    /**
     * JsonConverter personnalisé pour gérer les différentes formats de date dans le JSON, avec une tolérance pour les formats inattendus et une sérialisation uniforme
     */
    private class DateTimeConverter : JsonConverter<DateTime>
    {
        private readonly string[] _formats;

        public DateTimeConverter(params string[] formats)
        {
            _formats = formats.Length > 0 ? formats : new[] { "yyyy-MM-ddTHH:mm:ssZ" };
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var s = reader.GetString() ?? string.Empty;
                if (DateTime.TryParseExact(s, _formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
                {
                    return dt;
                }

                if (DateTime.TryParse(s, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                {
                    return dt;
                }

                return DateTime.MinValue;
            }

            return reader.GetDateTime();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_formats[0], CultureInfo.InvariantCulture));
        }
    }

    /**
     * Fonction asynchrone pour ajouter un event au json
     */
    public async Task SaveEventsAsync(List<OutdoorEvents> events)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };
        options.Converters.Add(new DateTimeConverter("MM-dd-yyyy"));
        options.Converters.Add(new JsonStringEnumConverter());
        var wrapper = new { events = events };
        var json = JsonSerializer.Serialize(wrapper, options);
        var directory = Path.GetDirectoryName(ResolveJsonPath());
        if (!string.IsNullOrWhiteSpace(directory))
        {
            Directory.CreateDirectory(directory);
        }

        await File.WriteAllTextAsync(ResolveJsonPath(), json);
    }
}