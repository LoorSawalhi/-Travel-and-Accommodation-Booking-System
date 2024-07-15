using Sieve.Attributes;

namespace TravelAndAccommodationBookingPlatform.API.DTOs;

public class HotelDto
{
    public string Name { get; set; }
    public int StarRating { get; set; }
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }
    public string Type { get; set; }
    
    public string CityName { get; set; }
}
