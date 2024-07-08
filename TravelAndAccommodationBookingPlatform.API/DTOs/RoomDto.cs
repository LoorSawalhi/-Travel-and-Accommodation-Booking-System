namespace TravelAndAccommodationBookingPlatform.API.DTOs;

public partial class RoomDto
{
    public string HotelName { get; set; }

    public string Availability { get; set; }

    public int AdultsCount { get; set; }

    public int ChildrenCount { get; set; }

    public decimal Price { get; set; }
}
