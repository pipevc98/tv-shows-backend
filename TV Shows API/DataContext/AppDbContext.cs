using Microsoft.EntityFrameworkCore;
using TV_Shows_API.Entities;

namespace TV_Shows_API.DataContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<TvShow> TvShows {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TvShow>().HasData(
                new TvShow { Id = 1, Nombre = "Breakin Bad", Favorite = true },
                new TvShow { Id = 2, Nombre = "The Boys", Favorite = true }
             );
        }


    }
}
