using AdoptionAgency.Backend.Configuration;
using AdoptionAgency.Backend.Domain.RepositoryInterfaces;
using AdoptionAgency.Backend.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace AdoptionAgency
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = CreateHost();
            ApplyMigrations();
        }

        private IHost CreateHost()
        {
            return Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                var databaseConfig = new DatabaseConfig();
                services.AddDbContext<DatabaseContext>(options =>
                    options.UseNpgsql(databaseConfig.GetConnectionString()));

                services.AddTransient<IPersonRepository, PersonRepository>();

            }).Build();
        }

        private void ApplyMigrations()
        {
            using (var scope = _host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
                db.Database.Migrate();
            }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync().Wait();
            base.OnExit(e);
        }
    }
}
