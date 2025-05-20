namespace Business.Models;
public class Booking
{
  public string? Id { get; set; }
  public string FirstName { get; set; } = null!;
  public string LastName { get; set; } = null!;

  public DateTime BookingDate { get; set; }

  public decimal? Amount { get; set; }
  public string EventId { get; set; } = null!;
  public int NumberOfTickets { get; set; }
}
