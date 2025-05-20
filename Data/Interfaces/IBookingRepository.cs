using Data.Entities;

namespace Data.Interfaces;
public interface IBookingRepository
{
  Task<bool> CreateBookingAsync(BookingEntity booking);
  Task<IEnumerable<BookingEntity>> GetAllBookingsAsync();
}