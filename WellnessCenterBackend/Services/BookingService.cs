using AutoMapper;
using WellnessCenterBackend.Database;
using WellnessCenterBackend.Entities;
using WellnessCenterBackend.Exceptions;
using WellnessCenterBackend.Models;

namespace WellnessCenterBackend.Services
{
    public interface IBookingService
    {
        int CreateBooking(BookingMassageDto dto);
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

            if (dto == null)
            {
                throw new BadRequestException("Wprowadzono nieprawidłowe dane");
            }

            dto.ServiceName = CheckNameBooking(dto.ServiceName);
            dto.BookingDay = CheckDayBooking(dto.BookingDay);
            dto.BookingHour = CheckHourBooking(dto.BookingHour);

            var booking = _mapper.Map<Booking>(dto);

            _context.Bookings.Add(booking);
           _context.SaveChanges();
            return booking.Id;
        }

        private string CheckNameBooking(string serviceName)
        {
            if (serviceName != "Chocolate Massage" && serviceName != "Honey Massage" && serviceName != "Classic Massage")
            {
                throw new BadRequestException("Nie ma takiej usługi");
            }
            return serviceName;
        }

        private int CheckDayBooking(int bookingDay)
        {
            if (bookingDay < 1 || bookingDay > 31)
            {
                throw new BadRequestException("Podano nieprawidłowy dzień");
            }
            return bookingDay;
        }

        private int CheckHourBooking(int bookingHour)
        {
            if(bookingHour < 1 || bookingHour > 24)
            {
                throw new BadRequestException("Podano nieprawidłową godzinę");
            }
            return bookingHour;
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
