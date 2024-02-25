using Libs.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Libs
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Images> Images { get; set; }
        public DbSet<Logins> Logins { get; set; }
        public DbSet<Diadiem> Diadiem { get; set; }
        public DbSet<Khuvucs> Khuvucs { get; set; }
        public DbSet<HotSpot> HotSpots { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

    }
}