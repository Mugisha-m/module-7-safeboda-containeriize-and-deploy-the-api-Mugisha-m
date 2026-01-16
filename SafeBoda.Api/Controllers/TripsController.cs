using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SafeBoda.Application;
using SafeBoda.Core;

namespace SafeBoda.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TripsController : ControllerBase
{
    private readonly ITripRepository _repo;
    private readonly IMemoryCache _cache;
    private const string AllTripsCacheKey = "trips:all";

    public TripsController(ITripRepository repo, IMemoryCache cache)
    {
        _repo = repo;
        _cache = cache;
    }

    // Task 5: Cached GET /api/trips
    [HttpGet]
    public async Task<IActionResult> GetAllTrips()
    {
        if (!_cache.TryGetValue<IEnumerable<Trip>>(AllTripsCacheKey, out var trips))
        {
            trips = await _repo.GetAllAsync();

            var options = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

            _cache.Set(AllTripsCacheKey, trips, options);
        }

        return Ok(trips);
    }

    // Task 2: Unit-testable synchronous path (matches your TripControllerTests)
    // GET /api/trips/active
    [HttpGet("active")]
    public IActionResult GetActiveTrips()
    {
        var trips = _repo.GetActiveTrips();
        return Ok(trips);
    }

    // GET /api/trips/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        if (id == Guid.Empty) return BadRequest("Invalid trip id.");

        var trip = await _repo.GetTripByIdAsync(id);
        if (trip is null) return NotFound();

        return Ok(trip);
    }

    // POST /api/trips
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Trip trip)
    {
        if (trip is null) return BadRequest("Trip payload required.");

        if (trip.Id == Guid.Empty)
            trip.Id = Guid.NewGuid();

        // Basic validation (extend as needed)
        if (trip.Start is null || trip.End is null)
            return BadRequest("Start and End locations are required.");

        _repo.AddTrip(trip);
        await _repo.SaveChangesAsync();

        // Invalidate cache after writes
        _cache.Remove(AllTripsCacheKey);

        return CreatedAtAction(nameof(GetById), new { id = trip.Id }, trip);
    }

    // DELETE /api/trips/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (id == Guid.Empty) return BadRequest("Invalid trip id.");

        _repo.DeleteTrip(id);
        await _repo.SaveChangesAsync();

        // Invalidate cache after deletes
        _cache.Remove(AllTripsCacheKey);

        return NoContent();
    }
}
