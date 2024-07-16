using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sieve.Models;
using Sieve.Services;
using TravelAndAccommodationBookingPlatform.Db.Data;
using TravelAndAccommodationBookingPlatform.Db.Mappers;
using TravelAndAccommodationBookingPlatform.Domain.IRepository;
using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.Db.Repositories;

public class HotelRepository(
    ISieveProcessor sieveProcessor,
    HotelsBookingSystemContext context,
    HotelMapper mapper,
    CityMapper cityMapper,
    RoomMapper roomMapper,
    ILogger<HotelRepository> logger)
    : IHotelRepository
{

    public async Task<Hotel?> GetHotelByName(string hotelName)
    {
        var hotel =  await context.Hotels
            .Where(hotel => hotel.Name.ToLower().Equals(hotelName.ToLower()))
            .Include(hotel => hotel.City)
            .FirstOrDefaultAsync();

        if (hotel == null) return null;
        
        var mappedHotel = mapper.MapFromDbToDomain(hotel);
        var city = cityMapper.MapFromDbToDomain(hotel.City);
        mappedHotel!.City = city;
        return mappedHotel;
    }

    public async Task<IEnumerable<Hotel>> GetHotelByStarRating(int starRating)
    {
        var hotels = await context.Hotels
            .Where(hotel => hotel.StarRating == starRating)
            .ToListAsync();
        return hotels.Select(hotel => mapper.MapFromDbToDomain(hotel));
    }

    public async Task<IEnumerable<Hotel>> GetHotelByPriceRange(decimal minPrice, decimal maxPrice)
    {
        return await context.Hotels.Select(hotel => mapper.MapFromDbToDomain(hotel))
            .Where(hotel => hotel.MinPrice >= minPrice && hotel.MaxPrice <= maxPrice)
            .ToListAsync();
    }

    public async Task<IEnumerable<Hotel>> GetHotelByCityName(string cityName)
    {
        return await context.Hotels.Select(hotel => mapper.MapFromDbToDomain(hotel))
            .Where(hotel => hotel.City.Name.Equals(cityName, StringComparison.InvariantCultureIgnoreCase))
            .ToListAsync();
    }

    public async Task<IEnumerable<Hotel>> GetAllHotels(SieveModel sieveModel)
    {
        var result = await sieveProcessor.Apply(sieveModel, context.Hotels)
            .Include(hotel =>hotel.City).ToListAsync();

        return result.Select(hotel => new
            {
                hotel = mapper.MapFromDbToDomain(hotel),
                city = cityMapper.MapFromDbToDomain(hotel.City)
            })
            .ToList()
            .Select(h =>
            {
                h.hotel.City = h.city;
                return h.hotel;
            });
    }

    public async Task<IEnumerable<Room>> GetHotelRooms(int hotelId)
    {
        var rooms = await context.Rooms.Where(room => room.HotelId == hotelId
        && room.Availability.Equals("Available")).ToListAsync();
        return rooms.Select(roomMapper.MapFromDbToDomain);
    }
}