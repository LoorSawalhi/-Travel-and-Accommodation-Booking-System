using Sieve.Attributes;

namespace TravelAndAccommodationBookingPlatform.Db.Models;

public class Hotel
{
    public int Id { get; set; }
    
    [Sieve(CanFilter = true, CanSort = true)]
    public string Name { get; set; }
    
    [Sieve(CanFilter = true, CanSort = true)]
    public int StarRating { get; set; }

    public string Owner { get; set; }

    public int CityId { get; set; }

    public decimal MinPrice { get; set; }

    public decimal MaxPrice { get; set; }
    
    [Sieve(CanFilter = true, CanSort = true)]
    public string Type { get; set; }

    public City City { get; set; }

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public ICollection<Room> Rooms { get; set; } = new List<Room>();
}
