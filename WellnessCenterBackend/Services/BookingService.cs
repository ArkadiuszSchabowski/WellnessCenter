using AutoMapper;
using WellnessCenterBackend.Database;
using WellnessCenterBackend.Entities;
using WellnessCenterBackend.Exceptions;
using WellnessCenterBackend.Models;
using WellnessCenterBackend.Validators;

namespace WellnessCenterBackend.Services
{
    public interface IBookingService
    {
        int CreateBooking(BookingMassageDto dto);
        object GetAll();
        Booking GetBooking(int id);
        void RemoveBooking(int id);
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
        public int CreateBooking(BookingMassageDto dto)
        {
            dto = BookingValidator.ValidatorDto(dto);

            var booking = _mapper.Map<Booking>(dto);

            _context.Bookings.Add(booking);
           _context.SaveChanges();
            return booking.Id;
        }

        public object GetAll()
        {
            return _context.Bookings.ToList();
        }
        public Booking GetBooking(int id)
        {
            var booking = GetBookingById(id);

            return booking;
        }

        public void RemoveBooking(int id)
        {
            var booking = GetBookingById(id);

            _context.Bookings.Remove(booking);
            _context.SaveChanges();
        }
        public Booking GetBookingById(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.Id == id);
            if (booking == null)
            {
                throw new NotFoundException("Booking not Found");
            }
            return booking;
        }
    }

}
