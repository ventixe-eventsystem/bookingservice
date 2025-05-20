
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Data.Repositories;
public class BookingRepository(DataContext context): IBookingRepository
{
  protected readonly DataContext _context = context;

  public async Task<IEnumerable<BookingEntity>> GetAllBookingsAsync()
  {
    return await _context.Booking.ToListAsync();
  }

  public async Task<bool> CreateBookingAsync(BookingEntity booking)
  {
    try
    {
      await _context.Booking.AddAsync(booking);
      await _context.SaveChangesAsync();
      return true;
    }
    catch (Exception ex)
    {
      Debug.WriteLine($"Error creating booking: {ex.Message}");
      return false;
    }
  }
}
