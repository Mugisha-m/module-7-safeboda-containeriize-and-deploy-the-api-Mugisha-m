using SafeBoda.Core; 
namespace SafeBoda.Application;
public interface ITripRepository
{
    IEnumerable<Trip> GetActiveTrips();
    void AddTrip(Trip trip);
    void DeleteTrip(Guid tripId);
    // void UpdateTrip(Guid tripId);
    // ITripRepository.cs
    Task<Trip?> GetTripByIdAsync(Guid id);
    Task SaveChangesAsync();
    // Change 'void' to 'Task<IEnumerable<Trip>>'
    Task<IEnumerable<Trip>> GetAllAsync();
}
