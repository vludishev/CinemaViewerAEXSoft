using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace CV.Infrastructure.Helpers
{
    public static class ConfigurationHelper
    {
        public static IConfiguration LoadConfiguration()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("CV.Infrastructure.appsettings.json") 
                ?? throw new FileNotFoundException("Embedded resource not found: CV.Infrastructure.appsettings.json");
            var configuration = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            return configuration;
        }
    }
}
