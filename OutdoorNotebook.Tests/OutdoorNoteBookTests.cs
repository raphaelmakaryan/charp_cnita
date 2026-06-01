using System.Collections.ObjectModel;
using OutdoorNotebook.Console.Models;

namespace OutdoorNotebook.Tests;

public class OutdoorNoteBookTests
{
    [Fact]
    public void UpComingRelease_ShouldReturnOnlyFutureEvents()
    {
        // Arrange
        EventService eventService = new EventService();
        Collection<OutdoorEvents> allEvents = eventService.CreateDefaultData();
        int expectedCount = allEvents.Count(e => e.Date1 >= DateTime.Today);
        var result = eventService.upComingRelease(allEvents);
        // Act
        foreach (var outdoorEvents in result)
        {
            Assert.False(outdoorEvents.Date1 <= DateTime.Today,
                "La sortie est passé pour : " + outdoorEvents.DisplayData(outdoorEvents));
        }

        Assert.Equal(expectedCount, result.Count);
    }

    [Fact]
    public void fullReleases_ShouldReturnOnlyFullEvents()
    {
        EventService eventService = new EventService();
        Collection<OutdoorEvents> allEvents = eventService.CreateDefaultData();
        int expectedCount = allEvents.Count(e => e.IsFull(e.ParticipantsActual1, e.MaxParticipants1));
        var result = eventService.fullReleases(allEvents);
        foreach (var outdoorEvents in result)
        {
            Assert.True(outdoorEvents.IsFull(outdoorEvents.ParticipantsActual1, outdoorEvents.MaxParticipants1),
                "La sortie n'est pas complete pour : " + outdoorEvents.DisplayData(outdoorEvents));
        }

        Assert.Equal(expectedCount, result.Count);
    }

    [Fact]
    public void releasesStillAvailable_ShouldReturnOnlyDispoEvent()
    {
        EventService eventService = new EventService();
        Collection<OutdoorEvents> allEvents = eventService.CreateDefaultData();
        int expectedCount = allEvents.Count(e =>
            !e.IsFull(e.ParticipantsActual1, e.MaxParticipants1) && e.Date1 >= DateTime.Today);
        var result = eventService.releasesStillAvailable(allEvents);
        foreach (var outdoorEvents in result)
        {
            Assert.False(
                outdoorEvents.IsFull(outdoorEvents.ParticipantsActual1, outdoorEvents.MaxParticipants1) &&
                outdoorEvents.Date1 <= DateTime.Today,
                "La sortie n'est pas disponible pour : " + outdoorEvents.DisplayData(outdoorEvents));
        }

        Assert.Equal(expectedCount, result.Count);
    }
}