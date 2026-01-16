// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;

// namespace SafeBoda.Infrastructure
// {
//     public class SafeBodaDbContextFactory : IDesignTimeDbContextFactory<SafeBodaDbContext>
//     {
//         public SafeBodaDbContext CreateDbContext(string[] args)
//         {
//             var optionsBuilder = new DbContextOptionsBuilder<SafeBodaDbContext>();

//             // Use your actual connection string here
//             optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SafeBodaDb;Trusted_Connection=True;");

//             return new SafeBodaDbContext(optionsBuilder.Options);
//         }
//     }
// }
