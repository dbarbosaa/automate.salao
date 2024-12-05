using Microsoft.Extensions.Configuration;
namespace AutomationTest.Core
{
    public class ConfigurationHelper
    {
        protected readonly IConfiguration _config;
        public ConfigurationHelper()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }
        public string WebDrivers =>_config.GetSection("DirWebDrivers").Value;
     //   public bool Headless => bool.Parse(_config.GetSection("Headless").Value);
     //   public bool IsBrowser => bool.Parse(_config.GetSection("IsBrowser").Value);
        public int LoadPageTimeout => int.Parse(_config.GetSection("LoadPageTimeout").Value);
    }
}