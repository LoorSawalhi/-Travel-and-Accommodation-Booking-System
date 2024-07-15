using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sieve.Models;
using Sieve.Services;
using TravelAndAccommodationBookingPlatform.Db.Data;
using TravelAndAccommodationBookingPlatform.Db.Mappers;
using TravelAndAccommodationBookingPlatform.Domain.IRepository;
using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly HotelsBookingSystemContext _context;
    private readonly HotelMapper _mapper;
    private readonly CityMapper _cityMapper;
    private readonly ILogger<HotelRepository> _logger;
    private readonly ISieveProcessor _sieveProcessor;

    public HotelRepository(ISieveProcessor sieveProcessor, HotelsBookingSystemContext context,
        HotelMapper mapper,CityMapper cityMapper, ILogger<HotelRepository> logger)
    {
        _context = context;
        _mapper = mapper;
        _cityMapper = cityMapper;
        _logger = logger;
        _sieveProcessor = sieveProcessor;
    }

    public async Task<IEnumerable<Hotel>> GetHotelByName(string hotelName)
    {
        var hotels =  await _context.Hotels
            .Where(hotel => hotel.Name.ToLower().Contains(hotelName.ToLower()))
            .ToListAsync();
        return hotels.Select(hotel => _mapper.MapFromDbToDomain(hotel));
    }

    public async Task<IEnumerable<Hotel>> GetHotelByStarRating(int starRating)
    {
        var hotels = await _context.Hotels
            .Where(hotel => hotel.StarRating == starRating)
            .ToListAsync();
        return hotels.Select(hotel => _mapper.MapFromDbToDomain(hotel));
    }

    public async Task<IEnumerable<Hotel>> GetHotelByPriceRange(decimal minPrice, decimal maxPrice)
    {
        return await _context.Hotels.Select(hotel => _mapper.MapFromDbToDomain(hotel))
            .Where(hotel => hotel.MinPrice >= minPrice && hotel.MaxPrice <= maxPrice)
            .ToListAsync();
    }

    public async Task<IEnumerable<Hotel>> GetHotelByCityName(string cityName)
    {
        return await _context.Hotels.Select(hotel => _mapper.MapFromDbToDomain(hotel))
            .Where(hotel => hotel.City.Name.Equals(cityName, StringComparison.InvariantCultureIgnoreCase))
            .ToListAsync();
    }

    public async Task<IEnumerable<Hotel>> GetAllHotels(SieveModel sieveModel)
    {
        var result = await _sieveProcessor.Apply(sieveModel, _context.Hotels)
            .Include(hotel =>hotel.City).ToListAsync();

        return result.Select(hotel => new
            {
                hotel = _mapper.MapFromDbToDomain(hotel),
                city = _cityMapper.MapFromDbToDomain(hotel.City)
            })
            .ToList()
            .Select(h =>
            {
                h.hotel.City = h.city;
                return h.hotel;
            });
    }
}