using DotNetEnv;

namespace AdoptionAgency.Backend.Configuration
{
    public class DatabaseConfig
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }

        public DatabaseConfig()
        {
            Env.Load(Constants.DOTENV_PATH);
            Host = Utils.GetEnv("HOST") ?? throw new Exception("Database host configuration error");
            Username = Utils.GetEnv("USERNAME") ?? throw new Exception("Database username configuration error");
            Password = Utils.GetEnv("PASSWORD") ?? throw new Exception("Database password configuration error");
            DatabaseName = Utils.GetEnv("DATABASE") ?? throw new Exception("Database database configuration error");
        }

        public string GetConnectionString()
        {
            return $"Host={Host};Database={DatabaseName};Username={Username};Password={Password}";
        }

    }
}
