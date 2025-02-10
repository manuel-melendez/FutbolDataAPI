using FutbolDataAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FutbolDataAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Club> Clubs { get; set; }
    }
}