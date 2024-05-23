using Microsoft.EntityFrameworkCore;
using WellnessCenterBackend.Database.Entities;

namespace WellnessCenterBackend.Database
{
    public class MyDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Massage> Massages { get; set; }
        public DbSet<Booking> CustomBookings { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Massage>().HasData(new Massage
            {
                Id = 1,
                ServiceName = "Chocolate Massage",
                ServiceTime = 60,
                Description = "Chocolate Massage - Description",
                Price = 199,
            },
            new Massage
            {
                Id = 2,
                ServiceName = "Honey Massage",
                ServiceTime = 45,
                Description = "Honey Massage Description",
                Price = 119,
            },
            new Massage
            {
                Id = 3,
                ServiceName = "Classic Massage",
                ServiceTime = 60,
                Description = "Clasic Massage Description",
                Price = 99,
            });
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = "User"
            },
            new Role
            {
                Id = 2,
                Name = "Manager"
            },
            new Role
            {
                Id = 3,
                Name = "Admin"
            });

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<User>().
                HasMany(b => b.Bookings).
                WithOne(u => u.User)
                .HasForeignKey(b => b.UserId);
        }
        
    }
}
