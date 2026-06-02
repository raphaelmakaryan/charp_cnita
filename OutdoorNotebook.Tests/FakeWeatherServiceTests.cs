using OutdoorNotebook.Core;

namespace OutdoorNotebook.Tests;

public class FakeWeatherServiceTests
{
    [Fact]
    public async Task GetWeatherAsync_ShouldReturnWeather_WhenLocationIsValid()
    {
        // Arrange
        var service = new FakeWeatherService();
        // Act
        var weather = await service.GetWeatherAsync(
            "Annecy",
            CancellationToken.None
        );

        // Assert
        Assert.Equal("Annecy", weather.Location);
    }

    [Fact]
    public async Task GetWeatherAsync_ShouldThrow_WhenLocationContainsErreur()
    {
        // Arrange
        var service = new FakeWeatherService();
        // Act / Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            service.GetWeatherAsync("ErreurVille", CancellationToken.None)
        );
    }

    [Fact]
    public async Task GetWeatherAsync_ShouldBeCancelable()
    {
        // Arrange
        var service = new FakeWeatherService();
        using var cts = new CancellationTokenSource();
        cts.CancelAfter(100);
        // Act / Assert
        await Assert.ThrowsAsync<TaskCanceledException>(() =>
            service.GetWeatherAsync("Annecy", cts.Token)
        );
    }
}