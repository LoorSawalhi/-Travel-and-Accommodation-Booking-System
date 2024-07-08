namespace TravelAndAccommodationBookingPlatform.API.DTOs;

public partial class ReservationDto
{
    public int? UserId { get; set; }

    public int? RoomId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal? Price { get; set; }

    public decimal? Discount { get; set; }

    public string HotelName { get; set; }
}
