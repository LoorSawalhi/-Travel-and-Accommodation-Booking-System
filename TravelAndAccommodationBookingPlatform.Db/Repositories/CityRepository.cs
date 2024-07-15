using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using TravelAndAccommodationBookingPlatform.Db.Data;
using TravelAndAccommodationBookingPlatform.Db.Mappers;
using TravelAndAccommodationBookingPlatform.Domain.IRepository;
using City = TravelAndAccommodationBookingPlatform.Domain.Models.City;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories;

public class CityRepository : ICityRepository
{
    private readonly HotelsBookingSystemContext _context;
    private readonly CityMapper _cityMapper;
    private readonly ISieveProcessor _sieveProcessor;
    private readonly HotelMapper _hotelMapper;

    public CityRepository(HotelsBookingSystemContext context, CityMapper cityMapper, ISieveProcessor sieveProcessor, HotelMapper hotelMapper)
    {
        _context = context;
        _cityMapper = cityMapper;
        _sieveProcessor = sieveProcessor;
        _hotelMapper = hotelMapper;
    }

    public IQueryable<City> GetCityByName(string cityName)
    {
        return _context.Cities.Select(city => _cityMapper.MapFromDbToDomain(city))
            .Where(city => city.Name.Equals(cityName, StringComparison.InvariantCultureIgnoreCase));
    }

    public async Task<IEnumerable<City>> GetAllCitiesAsync(SieveModel sieveModel)
    {
        var result = await _sieveProcessor.Apply(sieveModel, _context.Cities)
            .Include(city => city.Hotels).ToListAsync();

        return result.Select(city => _cityMapper.MapFromDbToDomain(city));
        // .Select(city => new
        // {
        //     // hotel = _hotelMapper.MapFromDbToDomain(city.Hotels),
        //     city = _cityMapper.MapFromDbToDomain(city)
        // })
        // .ToList()
        // .Select(h =>
        // {
        //     h.hotel.City = h.city;
        //     return h.hotel;
        // });
    }
}