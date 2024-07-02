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
            Host = Utils.GetEnv("HOST");
            Username = Utils.GetEnv("USERNAME");
            Password = Utils.GetEnv("PASSWORD");
            DatabaseName = Utils.GetEnv("DATABASE");
        }

        public string GetConnectionString()
        {
            return $"Host={Host};Database={DatabaseName};Username={Username};Password={Password}";
        }

    }
}
