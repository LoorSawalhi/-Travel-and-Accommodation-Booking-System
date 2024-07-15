namespace TravelAndAccommodationBookingPlatform.Domain.Models;

public class Hotel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int StarRating { get; set; }

    public string Owner { get; set; }

    public int CityId { get; set; }

    public decimal MinPrice { get; set; }

    public decimal MaxPrice { get; set; }

    public string Type { get; set; }

    public City City { get; set; }

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public ICollection<Room> Rooms { get; set; } = new List<Room>();
}
