using Microsoft.EntityFrameworkCore;
using WellnessCenterBackend.Entities;

namespace WellnessCenterBackend.Database
{
    public class MyDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MassageName> MassageNames { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MassageName>().HasData(new MassageName
            {
                Id = 1,
                ServiceName = "Chocolate Massage",
                ServiceTime = 60,
                Description = "Chocolate Massage - Description",
                Price = 199,
            },
            new MassageName
            {
                Id = 2,
                ServiceName = "Honey Massage",
                ServiceTime = 45,
                Description = "Honey Massage Description",
                Price = 119,
            },
            new MassageName
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

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Login = "Dominika123",
                HashPassword = "12345",
                Phone = "500-600-700",
                FirstName = "Dominika",
                LastName = "Zając",
                Email = "zajączek@o2.pl",
                RoleId = 1
            },
            new User
            {
                Id = 2,
                Login = "Paulina123",
                HashPassword = "23456",
                Phone = "501-601-701",
                FirstName = "Paulina",
                LastName = "Młyniok",
                Email = "młyniok@o2.pl",
                RoleId = 2
            },
            new User
            {
                Id = 3,
                Login = "Renata123",
                HashPassword = "34567",
                Phone = "502-602-702",
                FirstName = "Renata",
                LastName = "Szum",
                Email = "szum@o2.pl",
                RoleId = 3,
            });
        }
    }
}
