using HomeGymApp.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeGymApp.src.Data
{
    public class HomeGymDbContext : DbContext
    {
        public HomeGymDbContext(DbContextOptions<HomeGymDbContext> options) : base(options) 
        {
        }

        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkItem> WorkItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Gym>()
                .HasKey(g => g.Id);

            modelBuilder.Entity<Person>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Session>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Exercise>()
                .HasKey(p => p.Name);

            modelBuilder.Entity<WorkItem>()
                .HasKey(p => p.Id);
        }
    }
}