using Microsoft.AspNetCore.Mvc;

namespace SafeBoda.Api.Controllers;

public record DriverDto(Guid Id, string Name, string LicenseNumber);

[ApiController]
[Route("api/[controller]")]
public class DriversController : ControllerBase
{
    // GET /api/drivers
    [HttpGet]
    public IActionResult GetDrivers()
    {
        // Replace with real repository when available.
        var drivers = new List<DriverDto>
        {
            new(Guid.NewGuid(), "Amina N.", "RWA-12345"),
            new(Guid.NewGuid(), "Kato M.", "RWA-67890")
        };

        return Ok(drivers);
    }
}
