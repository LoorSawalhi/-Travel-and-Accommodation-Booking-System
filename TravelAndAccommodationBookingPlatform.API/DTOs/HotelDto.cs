namespace TravelAndAccommodationBookingPlatform.API.DTOs;

public partial class HotelDto
{
    public string Name { get; set; }

    public int StarRating { get; set; }

    public string Owner { get; set; }

    public int CityId { get; set; }

    public decimal MinPrice { get; set; }

    public decimal MaxPrice { get; set; }

    public string Type { get; set; }

    public string CityName { get; set; }
}
