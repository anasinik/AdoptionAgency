using AdoptionAgency.Backend.Configuration;
using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Backend.Domain.Model.User;
using AdoptionAgency.Backend.Domain.RepositoryInterfaces;
using AdoptionAgency.Backend.Helpers;
using AdoptionAgency.Backend.Repositories;
using AdoptionAgency.Backend.Repositories.AnimalRepositories;
using AdoptionAgency.Frontend.ViewModel.Authentication;
using AdoptionAgency.Frontend;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using AdoptionAgency.Frontend.ViewModel;

namespace AdoptionAgency
{
    public partial class App : Application
    {
        private readonly IHost _host;
        public static User LoggedUser;
        public App()
        {
            _host = CreateHost();
            ServiceProviderHelper.SetServiceProvider(_host.Services as ServiceProvider);
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
                services.AddTransient<ICrudRepository<Animal>, AnimalRepository>();
                services.AddTransient<ICrudRepository<AnimalRating>, AnimalRatingRepository>();
                services.AddTransient<ICrudRepository<AnimalSpecies>, AnimalSpeciesRepository>();
                services.AddTransient<ICrudRepository<AdoptionRequest>, AdoptionRequestRepository>();

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

            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(),
                Title = "LangLang"
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync().Wait();
            base.OnExit(e);
        }
    }
}
