using Riok.Mapperly.Abstractions;
using TravelAndAccommodationBookingPlatform.API.DTOs;
using TravelAndAccommodationBookingPlatform.Domain.Models;

namespace TravelAndAccommodationBookingPlatform.API.Mappers;

[Mapper]
public partial class HotelMapper
{
    public partial Hotel MapFromAPIToDomain(HotelDto hotel);

    public HotelDto MapFromDomainToAPI(Hotel hotel)
    {
        return new HotelDto
        {
            Name = hotel.Name,
            StarRating = hotel.StarRating,
            MinPrice = hotel.MinPrice,
            MaxPrice = hotel.MaxPrice,
            Type = hotel.Type,
            CityName = hotel.City.Name 
        };
    }
}