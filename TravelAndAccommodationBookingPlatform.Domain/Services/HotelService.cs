using Sieve.Models;
using Sieve.Services;
using TravelAndAccommodationBookingPlatform.Domain.Exceptions;
using TravelAndAccommodationBookingPlatform.Domain.IRepository;
using TravelAndAccommodationBookingPlatform.Domain.IServices;
using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.Domain.Services;

public class HotelService(IHotelRepository hotelRepository)
    : IHotelService
{
    
    public async Task<IEnumerable<Hotel>> FindHotelsAsync(SieveModel sieveModel)
    {
        return await hotelRepository.GetAllHotels(sieveModel);
    }

    public async Task<Hotel> FindHotelsByNameAsync(string name)
    {
        var hotel = await hotelRepository.GetHotelByName(name);
        if (hotel == null)
            throw new HotelNotFound($"No existing hotel with such name {name}");
        
        return (await hotelRepository.GetHotelByName(name))!;
    }

    public async Task<IEnumerable<Hotel>> FindHotelsByRatingAsync(int rating)
    {
        return await hotelRepository.GetHotelByStarRating(rating);
    }
}