using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TravelAndAccommodationBookingPlatform.Db.Models;

public class HotelsBookingSystemContextFactory : IDesignTimeDbContextFactory<HotelsBookingSystemContext>
{
    public HotelsBookingSystemContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<HotelsBookingSystemContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlServer(connectionString);

        return new HotelsBookingSystemContext(optionsBuilder.Options);
    }
}