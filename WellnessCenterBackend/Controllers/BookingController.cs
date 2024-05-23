using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public ActionResult AddBookingWithoutLogin([FromBody] BookingDto dto)
        {
            _service.AddBookingWithoutLogin(dto);
            return Ok();
        }
    }
}
