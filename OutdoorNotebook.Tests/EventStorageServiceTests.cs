using OutdoorNotebook.Core;

namespace OutdoorNotebook.Tests;

public class EventStorageServiceTests
{
    [Fact]
    public async Task SaveEventsAsync_ThenLoadEventsAsync_ShouldReturnSavedEvents()
    {
        // Arrange
        var storage = new EventStorageServiceAsync();
        var events = new List<OutdoorEvents>
        {
            new OutdoorEvents(0, "Randonnée au Parmelan", DateTime.Today.AddDays(5), "Annecy", 12, 3,
                "Sortie tranquille", EventsDifficulty.Difficile, 200, "Parking du col de la Forclaz"),
            new OutdoorEvents(1, "Sortie vélo autour du lac", DateTime.Today.AddDays(+2), "Annecy", 8, 8, null,
                EventsDifficulty.Facile, 100, "Porte de la chappelle"),
            new OutdoorEvents(2, "Kayak", DateTime.Today.AddDays(+10), "Cran-Gevrier", 20, 5, null,
                EventsDifficulty.Normal, 300, "Porte de la chappelle"),
            new OutdoorEvents(3, "Jogging", DateTime.Today.AddDays(+1), "Annecy", 12, 12, null, EventsDifficulty.Facile,
                200, "Porte de la chappelle"),
            new OutdoorEvents(4, "Canoe", DateTime.Today.AddDays(+5), "Annecy", 12, 0, null, EventsDifficulty.Normal,
                300,
                "Porte de la chappelle")
        };
        // Act
        await storage.SaveEventsAsync(events);
        var loadedEvents = await storage.LoadEventsAsync();
        OutdoorEvents.DisplayData(loadedEvents[0]);
        Assert.Single(loadedEvents);
        Assert.Equal("Randonnée au Parmelan", loadedEvents[0].Name);
    }
}