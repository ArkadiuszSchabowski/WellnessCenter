namespace WellnessCenterBackend.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string Price { get; set; }
        public DateTime Date { get; set; }
        public bool isPaid { get; set; }
    }
}
