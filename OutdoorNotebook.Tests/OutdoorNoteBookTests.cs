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
                "La sortie est passé pour : " + OutdoorEvents.DisplayData(outdoorEvents));
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
                "La sortie n'est pas complete pour : " + OutdoorEvents.DisplayData(outdoorEvents));
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
                "La sortie n'est pas disponible pour : " + OutdoorEvents.DisplayData(outdoorEvents));
        }

        Assert.Equal(expectedCount, result.Count);
    }

    [Fact]
    public void verificationData_ShouldReturnOnlyGoodData()
    {
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