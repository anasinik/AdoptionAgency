using AdoptionAgency.Backend.Configuration;
using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Backend.Domain.Model.Person;
using Microsoft.EntityFrameworkCore;

namespace AdoptionAgency.Backend.Repositories
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Animal> Animal {  get; set; }
        public DbSet<AnimalSpecies> AnimalSpecies { get; set; }
        public DbSet<AnimalRating> AnimalRating { get; set; }
        public DbSet<AdoptionRequest> AdoptionRequest {  get; set; }
        public DbSet<Person> Person { get; set; }

        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().ToTable(nameof(Person));
            modelBuilder.Entity<Animal>().ToTable(nameof(Animal));
            modelBuilder.Entity<AnimalSpecies>().ToTable(nameof(AnimalSpecies));
            modelBuilder.Entity<AnimalRating>().ToTable(nameof(AnimalRating));
            modelBuilder.Entity<AdoptionRequest>().ToTable(nameof(AdoptionRequest));
            ConfigurePersonEntity(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DatabaseConfig config = new();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(config.GetConnectionString());
            }
        }

        private void ConfigurePersonEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .OwnsOne(p => p.User, user =>
                {
                    user.Property(u => u.Username).HasColumnName("Username");
                    user.Property(u => u.Password).HasColumnName("Password");
                    user.Property(u => u.Type).HasColumnName("Type");
                });
        }
    }
}
