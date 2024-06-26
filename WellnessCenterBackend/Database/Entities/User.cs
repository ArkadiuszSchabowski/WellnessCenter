﻿namespace WellnessCenterBackend.Database.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string HashPassword { get; set; }
        public string? Phone { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
