using System;
using System.Collections.Generic;

namespace ETour.DbRepos;

public partial class Booking
{
    internal object id;

    public int BookingId { get; set; }

    public string? BookingDate { get; set; }

    public int CustomerId { get; set; }

    public int Flag { get; set; }

    public string? MsgBody { get; set; }

    public int PackageId { get; set; }

    public string? Recipient { get; set; }

    public double Taxes { get; set; }

    public double TotalAmount { get; set; }

    public double TourAmount { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Package Package { get; set; } = null!;

    public virtual ICollection<Passenger> Passengers { get; set; } = new List<Passenger>();
}
