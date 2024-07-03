using Microsoft.Extensions.DependencyInjection;

namespace AdoptionAgency.Backend.Helpers
{
    public class ServiceProviderHelper
    {
        private static ServiceProvider _serviceProvider;

        public static void SetServiceProvider(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static T GetService<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
