using System.ComponentModel.DataAnnotations.Schema;
using WellnessCenterBackend.Exceptions;

namespace WellnessCenterBackend.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BookingDay { get; set; }
        public int BookingHour { get; set; }
        public int MassageNameId { get; set; }
        public MassageName MassageName { get; set; }
        public bool IsPaid { get; set; } = false;
    }
}
