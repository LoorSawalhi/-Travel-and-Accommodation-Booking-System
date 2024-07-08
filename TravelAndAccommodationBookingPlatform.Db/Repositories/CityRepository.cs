using TravelAndAccommodationBookingPlatform.Db.Data;
using TravelAndAccommodationBookingPlatform.Db.Mappers;
using TravelAndAccommodationBookingPlatform.Domain.IRepository;
using City = TravelAndAccommodationBookingPlatform.Domain.Models.City;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories;

public class CityRepository : ICityRepository
{
    private readonly HotelsBookingSystemContext _context;
    private readonly CityMapper _mapper;

    public CityRepository(HotelsBookingSystemContext context, CityMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IQueryable<City> GetCityByName(string cityName)
    {
        return _context.Cities.Select(city => _mapper.MapFromDbToDomain(city))
            .Where(city => city.Name.Equals(cityName, StringComparison.InvariantCultureIgnoreCase));
    }
}