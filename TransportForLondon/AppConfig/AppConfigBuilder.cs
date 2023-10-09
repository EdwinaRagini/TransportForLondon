using Microsoft.Extensions.Configuration;

namespace TFLFramework.AppConfig
{
    public class AppConfigBuilder
    {
        private static AppSettings? _instance;
        public static AppSettings Instance => _instance ?? Create();

        private static AppSettings Create()
        {

            var contentRoot = Directory.GetCurrentDirectory();
            var config = new ConfigurationBuilder()
                .SetBasePath(contentRoot)
                .AddJsonFile("appSettings.json")
                .AddEnvironmentVariables()
                .Build();

            return _instance = config.GetSection("appSettings").Get<AppSettings>();
        }
    }
}
