namespace AdoptionAgency.Backend.Configuration
{
    public static class Utils
    {
        public static string? GetEnv(string variable)
        {
            return Environment.GetEnvironmentVariable(variable);
        }
    }
}
