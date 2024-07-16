namespace TravelAndAccommodationBookingPlatform.Domain.Models;

public partial class Reservation
{
    public int UserId { get; set; }

    public int HotelId { get; set; }

    public int RoomId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public decimal Price { get; set; }

    public decimal Discount { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual Room Room { get; set; }

    public virtual User User { get; set; }
}
