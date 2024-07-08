namespace TravelAndAccommodationBookingPlatform.Domain.Models;

public partial class Room
{
    public int Id { get; set; }

    public int? HotelId { get; set; }

    public string? Availability { get; set; }

    public int? AdultsCount { get; set; }

    public int? ChildrenCount { get; set; }

    public decimal? Price { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
