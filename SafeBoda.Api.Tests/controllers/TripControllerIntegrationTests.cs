using Xunit;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

public class TripControllerIntegrationTests 
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public TripControllerIntegrationTests(
        WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetTrips_ReturnsSuccess()
    {
        var response = await _client.GetAsync("/api/trips");

        response.EnsureSuccessStatusCode();
    }
}
