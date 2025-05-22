using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;
public class BookingEntity
{
  [Key]
  public string Id { get; set; } = Guid.NewGuid().ToString();
  public string FirstName { get; set; } = null!;
  public string LastName { get; set; } = null!;

  [Column(TypeName = "datetime2")]
  public DateTime BookingDate { get; set; } = DateTime.Now;

  [Column(TypeName = "decimal(18,2)")]
  public decimal? Amount { get; set; }
  public string EventId { get; set; } = null!;
  public int NumberOfTickets { get; set; } = 1;

  public string? UserId { get; set; }
}
