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

    [Fact]
    public void verificationData_ShouldReturnOnlyGoodData()
    {
        Collection<OutdoorEvents> goodData = new Collection<OutdoorEvents>()
        {
            new OutdoorEvents("Randonnée au Parmelan", DateTime.Today.AddDays(-1), "Annecy", 12, 3, null),
            new OutdoorEvents("Sortie vélo autour du lac", DateTime.Today.AddDays(+2), "Annecy", 8, 8, null),
            new OutdoorEvents("Kayak", DateTime.Today.AddDays(+10), "Cran-Gevrier", 20, 5, null),
            new OutdoorEvents("Jogging", DateTime.Today.AddDays(+1), "Annecy", 12, 12, null),
            new OutdoorEvents("Canoe", DateTime.Today.AddDays(+5), "Annecy", 12, 0, null)
        };

        Collection<OutdoorEvents> badData = new Collection<OutdoorEvents>()
        {
            new OutdoorEvents("Randonnée au Parmelan", DateTime.Today.AddDays(-1), "Annecy", 12, 3, null),
            new OutdoorEvents("Sortie vélo autour du lac", DateTime.Today.AddDays(+2), "", 8, 8, null),
            new OutdoorEvents("Kayak", DateTime.Today.AddDays(+10), "Cran-Gevrier", -40, 5, null),
            new OutdoorEvents("Jogging", DateTime.Today.AddDays(+1), "Annecy", 12, 12, null),
            new OutdoorEvents("", DateTime.Today.AddDays(+5), "Annecy", 12, 0, null)
        };
        EventService eventService = new EventService();
        Collection<OutdoorEvents> allEvents = eventService.CreateDefaultData();

        /*
        bool isValid = eventService.verificationEvent(goodData);
        Assert.True(isValid);
        bool isInvalid = eventService.verificationEvent(badData);
        Assert.False(isInvalid);
        */
        bool isValid = eventService.verificationEvent(allEvents);
        Assert.True(isValid);
    }
}