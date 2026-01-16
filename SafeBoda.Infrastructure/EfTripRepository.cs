using SafeBoda.Core;
using SafeBoda.Application;
using Microsoft.EntityFrameworkCore;

namespace SafeBoda.Infrastructure;

public class EfTripRepository : ITripRepository
{
    private readonly SafeBodaDbContext _context;

    public EfTripRepository(SafeBodaDbContext context)
    {
        _context = context;
    }



     public async Task<Trip?> GetTripByIdAsync(Guid id)
    {
        return await _context.Trips.FindAsync(id);
    }

   
    public async Task UpdateTripAsync(Trip trip)
    {
        _context.Trips.Update(trip);
        await _context.SaveChangesAsync();
    }

     public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }



    public IEnumerable<Trip> GetActiveTrips()
    {
        return _context.Trips.ToList();
    }

    public void AddTrip(Trip trip)
    {
        _context.Trips.Add(trip);
        _context.SaveChanges();
    }

    // public void UpdateTrip(Trip trip)
    // {
    //     _context.Trips.Update(trip);
    //     _context.SaveChanges();
    // }

    public void DeleteTrip(Guid tripId)
    {
        var trip = _context.Trips.Find(tripId);
        if (trip != null)
        {
            _context.Trips.Remove(trip);
            _context.SaveChanges();
        }
    }

    public async Task<IEnumerable<Trip>> GetAllAsync()
{
    // This uses Entity Framework to get all trips from the database
    // Assuming your DbSet is named 'Trips'
    return await _context.Trips.ToListAsync();
}

}
