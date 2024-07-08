using TravelAndAccommodationBookingPlatform.Db.Data;
using TravelAndAccommodationBookingPlatform.Domain.IRepository;
using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.Db.Repository;

public class CityRepository : ICityRepository
{
    private readonly HotelsBookingSystemContext _context;

    public CityRepository(HotelsBookingSystemContext context)
    {
        _context = context;
    }

    public IQueryable<City> GetCityByName(string cityName)
    {
        return _context.Cities.Where(city => city.Name.Equals(cityName, StringComparison.InvariantCultureIgnoreCase));
    }
}