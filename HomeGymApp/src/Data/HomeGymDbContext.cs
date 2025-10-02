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
                .HasKey(s => s.Id);

            modelBuilder.Entity<Exercise>()
                .HasKey(e => e.Name);

            modelBuilder.Entity<ExercisePerformance>()
                .HasKey(ep => ep.Id);

            modelBuilder.Entity<ExerciseSet>()
                .HasKey(es => es.Id);

            modelBuilder.Entity<WorkItem>()
                .HasKey(w => w.Id);

            // Relationships
            modelBuilder.Entity<ExercisePerformance>()
                .HasOne(ep => ep.Exercise)
                .WithMany()
                .HasForeignKey(ep => ep.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExercisePerformance>()
                .HasMany(ep => ep.Sets)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Session>()
                .HasMany(s => s.ExercisePerformances)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}