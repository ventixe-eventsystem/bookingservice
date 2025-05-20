using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;
public class BookingService(IBookingRepository repository) : IBookingService
{
  private readonly IBookingRepository _repository = repository;

  public async Task<bool> CreateBookingAsync(Booking booking)
  {
    try
    {
      var bookingEntity = new BookingEntity
      {
        FirstName = booking.FirstName,
        LastName = booking.LastName,
        BookingDate = booking.BookingDate,
        Amount = booking.Amount,
        EventId = booking.EventId,
        NumberOfTickets = booking.NumberOfTickets
      };
      return await _repository.CreateBookingAsync(bookingEntity);
    }
    catch (Exception ex)
    {
      Debug.WriteLine($"Error creating booking: {ex.Message}");
      return false;
    }
  }

  public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
  {
    try
    {
      var bookings = await _repository.GetAllBookingsAsync();
      return bookings.Select(b => new Booking
      {
        Id = b.Id,
        FirstName = b.FirstName,
        LastName = b.LastName,
        BookingDate = b.BookingDate,
        Amount = b.Amount,
        EventId = b.EventId,
        NumberOfTickets = b.NumberOfTickets
      });
    }
    catch (Exception ex)
    {
      Debug.WriteLine($"Error retrieving bookings: {ex.Message}");
      return [];
    }
  }
}
