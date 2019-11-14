using Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace Entities.Context
{
    public class SmartBoxContext: DbContext
    {
        public SmartBoxContext(DbContextOptions<SmartBoxContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<SmartBox> SmartBoxes { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SmartBox>()
                .HasMany(c => c.Locations)
                .WithOne().HasForeignKey(p => p.BoxId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
