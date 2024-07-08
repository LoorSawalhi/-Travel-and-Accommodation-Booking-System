namespace TravelAndAccommodationBookingPlatform.Domain.Models;

public partial class Hotel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int StarRating { get; set; }

    public string Owner { get; set; }

    public int CityId { get; set; }

    public decimal MinPrice { get; set; }

    public decimal MaxPrice { get; set; }

    public string Type { get; set; }

    public virtual City City { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
