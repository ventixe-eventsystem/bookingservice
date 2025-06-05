using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookingApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BookingController(IBookingService bookingService) : ControllerBase
{
  private readonly IBookingService _bookingService = bookingService;

  [HttpPost]
  public async Task<IActionResult> CreateBooking([FromBody] Booking booking)
  {
    try
    {
      if (booking == null)
        return BadRequest("Booking cannot be null");

      var result = await _bookingService.CreateBookingAsync(booking);
      if (!result)
        return StatusCode(500, "Internal server error");

      return Ok();
    }
    catch (Exception ex)
    {
      Debug.WriteLine($"Error creating booking: {ex.Message}");
      return StatusCode(500, "Internal server error");
    }
  }

  [HttpGet]
  public async Task<IActionResult> GetAllBookings()
  {
    try
    {
      var bookings = await _bookingService.GetAllBookingsAsync();
      if (bookings == null || !bookings.Any())
        return NotFound("No bookings found");
      return Ok(bookings);
    }
    catch (Exception ex)
    {
      Debug.WriteLine($"Error retrieving bookings: {ex.Message}");
      return StatusCode(500, "Internal server error");
    }
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetBookingById(string id)
  {
    if (string.IsNullOrEmpty(id))
      return BadRequest("Booking ID cannot be null or empty");
    try
    {
      var allBookings = await _bookingService.GetAllBookingsAsync();
      var bookings = allBookings.Where(b => b.UserId == id);
      if (bookings == null)
        return NotFound($"Bookings with ID {id} not found");
      return Ok(bookings);
    }
    catch (Exception ex)
    {
      Debug.WriteLine($"Error retrieving booking by ID: {ex.Message}");
      return StatusCode(500, "Internal server error");
    }
  }
}
