using System;
using System.Collections.Generic;

namespace TravelAndAccommodationBookingPlatform.Db.Models;

public partial class User
{
    public int Id { get; set; }

    public string? PassportId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
