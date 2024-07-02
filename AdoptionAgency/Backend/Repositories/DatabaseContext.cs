using AdoptionAgency.Backend.Domain.Model.Person;
using Microsoft.EntityFrameworkCore;

namespace AdoptionAgency.Backend.Repositories
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }

        public DbSet<Person> Person { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigurePersonEntity(modelBuilder);
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
