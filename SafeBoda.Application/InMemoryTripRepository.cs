using SafeBoda.Core;
using System.Collections.Generic;
using System.Linq;

namespace SafeBoda.Application;

public class InMemoryTripRepository : ITripRepository
{
   
    private readonly List<Trip> _trips;

    public Task SaveChangesAsync()
{

    return Task.CompletedTask;
}


    public InMemoryTripRepository()
    {
        _trips = new List<Trip>
        {
            new Trip(
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                new Location(-1.95, 30.09),
                new Location(-1.94, 30.10),
                1500m,
                DateTime.Now
            ),
            new Trip(
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                new Location(-1.94, 30.10),
                new Location(-1.93, 30.12),
                2000m,
                DateTime.Now.AddMinutes(-10)
            )
        };
    }

    public IEnumerable<Trip> GetActiveTrips() => _trips;

    
    public Trip? GetTripById(Guid id) => _trips.FirstOrDefault(t => t.Id == id);

    
    public void AddTrip(Trip  trip) => _trips.Add(trip);

    public void DeleteTrip(Guid tripId)
    {
        var trip = _trips.Find(t => t.Id == tripId);
        if (trip != null)
        {
            _trips.Remove(trip);
            // _trips.SaveChanges();
        }
    }
     public Task<Trip?> GetTripByIdAsync(Guid id)
    {
        var trip = _trips.FirstOrDefault(t => t.Id == id);
        return Task.FromResult(trip);
    }

    public async Task<IEnumerable<Trip>> GetAllAsync()
{
    // This returns your local list of trips wrapped in a Task
    // Replace '_trips' with whatever your local List name is
    return await Task.FromResult(_trips); 
}

}