using AutoMapper;
using WellnessCenterBackend.Database;
using WellnessCenterBackend.Database.Entities;
using WellnessCenterBackend.Models;

namespace WellnessCenterBackend.Services
{
    public interface IBookingService
    {
        void AddBookingWithoutLogin(BookingDto dto);
    }
    public class BookingService : IBookingService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public BookingService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void AddBookingWithoutLogin(BookingDto dto)
        {
            var newBooking = _mapper.Map<Booking>(dto);

            _context.CustomBookings.Add(newBooking);
            _context.SaveChanges();
        }
    }
}