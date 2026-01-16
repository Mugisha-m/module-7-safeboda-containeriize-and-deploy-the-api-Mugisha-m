using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafeBoda.Admin.Services
{
    public class TripsClient
    {
        private readonly ApiClient _api;

        public TripsClient(ApiClient api)
        {
            _api = api;
        }

        public async Task<List<TripDto>> GetActiveTripsAsync()
        {
            return await _api.GetAsync<List<TripDto>>("api/trips");
        }
    }

    public class TripDto
    {
        public int Id { get; set; }
        public string DriverName { get; set; }
        public string Status { get; set; }
    }
}