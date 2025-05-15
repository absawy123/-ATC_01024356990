using Events.core.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace WebApp.Infrastructure.persistence
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public AppDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionString = config.GetConnectionString("constr");
            optionsBuilder.UseSqlServer(connectionString);

        }


        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Event> Events { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);


            // seed Roles
            builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "adminRoleId", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "userRoleId", Name = "User", NormalizedName = "USER" }

            );

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "userId",
                    UserName = "ahmedemam@mail.com",
                    NormalizedUserName = "AHMEDEMAM@MAIL.COM",
                    Email = "ahmedemam@mail.com",
                    NormalizedEmail = "AHMEDEMAM@MAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(new ApplicationUser(), "12345678"),
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser
                {
                    Id = "userId2",
                    UserName = "ahmedtaher@mail.com",
                    NormalizedUserName = "AHMEDTAHER@MAIL.COM",
                    Email = "ahmedtaher@mail.com",
                    NormalizedEmail = "AHMEDTAHER@MAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(new ApplicationUser(), "12345678"),
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "userId", RoleId = "AdminRoleId" }, // SuperAdmin
                new IdentityUserRole<string> { UserId = "userId2", RoleId = "userRoleId" } // Inspector 
              
            );

        }

    }
}
