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
                "Sortie tranquille", EventsDifficulty.Difficile, 200, "Parking du col de la Forclaz")
        };
        // Act
        await storage.SaveEventsAsync(events);
        var loadedEvents = await storage.LoadEventsAsync();
        OutdoorEvents.DisplayData(loadedEvents[0]);
        Assert.Single(loadedEvents);
        Assert.Equal("Randonnée au Parmelan", loadedEvents[0].Name);
    }
}