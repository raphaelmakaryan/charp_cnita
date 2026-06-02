using System.Collections.ObjectModel;
using OutdoorNotebook.Core;


namespace OutdoorNotebook.Tests;

public class OutdoorNoteBookTests
{
    [Fact]
    public void UpComingRelease_ShouldReturnOnlyFutureEvents()
    {
        // Arrange
        EventService eventService = new EventService();
        Collection<OutdoorEvents> allEvents = eventService.CreateDefaultData();
        int expectedCount = allEvents.Count(e => e.Date >= DateTime.Today);
        var result = eventService.UpComingRelease(allEvents);
        // Act
        foreach (var outdoorEvents in result)
        {
            Assert.False(outdoorEvents.Date <= DateTime.Today,
                "La sortie est passé pour : " + outdoorEvents.DisplayData(outdoorEvents));
        }

        Assert.Equal(expectedCount, result.Count);
    }

    [Fact]
    public void fullReleases_ShouldReturnOnlyFullEvents()
    {
        EventService eventService = new EventService();
        Collection<OutdoorEvents> allEvents = eventService.CreateDefaultData();
        int expectedCount = allEvents.Count(e => e.IsFull(e.ParticipantsActual, e.MaxParticipants));
        var result = eventService.FullReleases(allEvents);
        foreach (var outdoorEvents in result)
        {
            Assert.True(outdoorEvents.IsFull(outdoorEvents.ParticipantsActual, outdoorEvents.MaxParticipants),
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
            !e.IsFull(e.ParticipantsActual, e.MaxParticipants) && e.Date >= DateTime.Today);
        var result = eventService.ReleasesStillAvailable(allEvents);
        foreach (var outdoorEvents in result)
        {
            Assert.False(
                outdoorEvents.IsFull(outdoorEvents.ParticipantsActual, outdoorEvents.MaxParticipants) &&
                outdoorEvents.Date <= DateTime.Today,
                "La sortie n'est pas disponible pour : " + outdoorEvents.DisplayData(outdoorEvents));
        }

        Assert.Equal(expectedCount, result.Count);
    }

    [Fact]
    public void verificationData_ShouldReturnOnlyGoodData()
    {
        Collection<OutdoorEvents> goodData =
        [
            new OutdoorEvents("Randonnée au Parmelan", DateTime.Today.AddDays(-1), "Annecy", 12, 3, null,
                EventsDifficulty.Facile),
            new OutdoorEvents("Sortie vélo autour du lac", DateTime.Today.AddDays(+2), "Annecy", 8, 8, null,
                EventsDifficulty.Normal),
            new OutdoorEvents("Kayak", DateTime.Today.AddDays(+10), "Cran-Gevrier", 20, 5, null,
                EventsDifficulty.Difficile),
            new OutdoorEvents("Jogging", DateTime.Today.AddDays(+1), "Annecy", 12, 12, null, EventsDifficulty.Facile),
            new OutdoorEvents("Canoe", DateTime.Today.AddDays(+5), "Annecy", 12, 0, null, EventsDifficulty.Difficile)
        ];

        Collection<OutdoorEvents> badData =
        [
            new OutdoorEvents("Randonnée au Parmelan", DateTime.Today.AddDays(-1), "Annecy", 12, 3, null,
                EventsDifficulty.Facile),
            new OutdoorEvents("Sortie vélo autour du lac", DateTime.Today.AddDays(+2), "", 8, 8, null,
                EventsDifficulty.Normal),
            new OutdoorEvents("Kayak", DateTime.Today.AddDays(+10), "Cran-Gevrier", -40, 5, null,
                EventsDifficulty.Difficile),
            new OutdoorEvents("Jogging", DateTime.Today.AddDays(+1), "Annecy", 12, 12, null, EventsDifficulty.Facile),
            new OutdoorEvents("", DateTime.Today.AddDays(+5), "Annecy", 12, 0, null, EventsDifficulty.Difficile)
        ];
        EventService eventService = new EventService();
        Collection<OutdoorEvents> allEvents = eventService.CreateDefaultData();

        /*
        bool isValid = eventService.verificationEvent(goodData);
        Assert.True(isValid);
        bool isInvalid = eventService.verificationEvent(badData);
        Assert.False(isInvalid);
        */
        bool isValid = eventService.VerificationEvent(allEvents);
        Assert.True(isValid);
    }
}