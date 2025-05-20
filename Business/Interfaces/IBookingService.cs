using Business.Models;

namespace Business.Interfaces;
public interface IBookingService
{
  Task<bool> CreateBookingAsync(Booking booking);
  Task<IEnumerable<Booking>> GetAllBookingsAsync();
}