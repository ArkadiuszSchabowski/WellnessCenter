namespace WellnessCenterBackend.Database.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public string MassageName { get; set; }
        public string Date { get; set; }
        public string Hour { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}

