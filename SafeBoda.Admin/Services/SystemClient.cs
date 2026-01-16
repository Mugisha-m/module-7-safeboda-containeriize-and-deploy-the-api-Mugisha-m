using System.Threading.Tasks;

namespace SafeBoda.Admin.Services
{
    public class SystemClient
    {
        private readonly ApiClient _api;

        public SystemClient(ApiClient api)
        {
            _api = api;
        }

        public async Task<SystemStatusDto> GetStatusAsync()
        {
            return await _api.GetAsync<SystemStatusDto>("api/admin/status");
        }
    }

    public class SystemStatusDto
    {
        public int ActiveTrips { get; set; }
        public int RegisteredDrivers { get; set; }
        public string Health { get; set; }
    }
}