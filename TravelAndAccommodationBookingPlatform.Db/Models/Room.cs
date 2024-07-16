namespace TravelAndAccommodationBookingPlatform.Db.Models;

public class Room
{
    public int Id { get; set; }

    public string RoomId { get; set; }
    public int HotelId { get; set; }

    public string Availability { get; set; }

    public int AdultsCount { get; set; }

    public int ChildrenCount { get; set; }

    public decimal Price { get; set; }

    public Hotel Hotel { get; set; }

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
