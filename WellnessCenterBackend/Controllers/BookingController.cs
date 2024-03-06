using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WellnessCenterBackend.Models;
using WellnessCenterBackend.Services;

namespace WellnessCenterBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;

        public BookingController(IBookingService service)
        {
            _service = service;
        }
        [HttpPost]
        public ActionResult BookingMassage(BookingMassageDto dto)
        {
            int id = _service.CreateBooking(dto);
            return Created("/api/booking/id", null);
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var bookings = _service.GetAll();
            return Ok(bookings);
        }

        [Authorize(Roles = "Manager, Admin")]
        [HttpGet("{id}")]
        public ActionResult GetBooking(int id)
        {
            var booking = _service.GetBooking(id);
            return Ok(booking);
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveBooking(int id)
        {
            _service.RemoveBooking(id);
            return NoContent();
        }
    }
}
