using Moq;
using Xunit;
using SafeBoda.Api.Controllers;
using SafeBoda.Application;
using SafeBoda.Core; // Required for Trip and Location
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class TripControllerTests
{
    private readonly Mock<ITripRepository> _repoMock;
    private readonly TripController _controller;

    public TripControllerTests()
    {
        _repoMock = new Mock<ITripRepository>();
        // This uses the REAL TripController from your Api project
        _controller = new TripController(_repoMock.Object);
    }

    [Fact]
public void GetAllActiveTrips_ReturnsOkResult()
{
    // 1. Arrange
    var fakeTrips = new List<Trip> 
    { 
        new Trip(
            Guid.NewGuid(), 
            Guid.NewGuid(), 
            Guid.Empty, 
            new Location(0, 0), 
            new Location(0, 0), 
            0, 
            DateTime.UtcNow) 
    };

    // Match the synchronous method from your ITripRepository
    _repoMock.Setup(r => r.GetActiveTrips()).Returns(fakeTrips);

    // 2. Act
    var result = _controller.GetAllActiveTrips();

    // 3. Assert
    var okResult = Assert.IsType<OkObjectResult>(result);
    Assert.NotNull(okResult.Value);
}
}