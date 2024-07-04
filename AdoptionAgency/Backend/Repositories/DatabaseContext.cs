using AdoptionAgency.Backend.Configuration;
using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Backend.Domain.Model.Person;
using AdoptionAgency.Backend.Domain.Model.Post;
using Microsoft.EntityFrameworkCore;

namespace AdoptionAgency.Backend.Repositories
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Animal> Animal {  get; set; }
        public DbSet<AnimalSpecies> AnimalSpecies { get; set; }
        public DbSet<AnimalRating> AnimalRating { get; set; }
        public DbSet<AdoptionRequest> AdoptionRequest {  get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Picture> Picture { get; set; }

        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().ToTable(nameof(Person));
            ConfigurePersonEntity(modelBuilder);

            ConfigureAnimalEntity(modelBuilder);
            modelBuilder.Entity<AnimalSpecies>().ToTable(nameof(AnimalSpecies));
            modelBuilder.Entity<AnimalRating>().ToTable(nameof(AnimalRating));
            modelBuilder.Entity<AdoptionRequest>().ToTable(nameof(AdoptionRequest));

            ConfigurePostEntity(modelBuilder);
            modelBuilder.Entity<Picture>().ToTable(nameof(Picture));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DatabaseConfig config = new();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(config.GetConnectionString());
            }
        }

        private void ConfigurePostEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable(nameof(Post));
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Animal)
                .WithMany()
                .HasForeignKey(p => p.AnimalId);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.Person)
                .WithMany()
                .HasForeignKey(p => p.PersonId);
        }

        private void ConfigureAnimalEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().ToTable(nameof(Animal));
            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Species)
                .WithMany()
                .HasForeignKey(a => a.SpeciesId);
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
