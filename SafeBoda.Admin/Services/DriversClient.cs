using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafeBoda.Admin.Services
{
    public class DriversClient
    {
        private readonly ApiClient _api;

        public DriversClient(ApiClient api)
        {
            _api = api;
        }

        public async Task<List<DriverDto>> GetDriversAsync()
        {
            return await _api.GetAsync<List<DriverDto>>("api/admin/drivers");
        }
    }

    public class DriverDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
    }
}