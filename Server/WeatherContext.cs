using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<WeatherInMoscow>().ToTable("WeatherInMoscow");
        }


        public DbSet<User> Users { get; set; }
        public DbSet<WeatherInMoscow> WeathersInMoscow { get; set; }
        
    }
}