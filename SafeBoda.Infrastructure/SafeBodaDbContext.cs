using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SafeBoda.Core;
using SafeBoda.Core.Identity;

namespace SafeBoda.Infrastructure
{
    public class SafeBodaDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Rider> Riders { get; set; }

        public SafeBodaDbContext(DbContextOptions<SafeBodaDbContext> options)
            : base(options)
        {
        }
    }
}
