namespace TravelAndAccommodationBookingPlatform.Db.Models;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string PostOffice { get; set; }

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
}
