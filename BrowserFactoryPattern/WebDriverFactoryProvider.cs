using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace SeleniumWithCucumber.BrowserFactoryPattern
{
    public class WebDriverFactoryProvider
    {
        private static IConfiguration _configuration;

        static WebDriverFactoryProvider()
        {
            // Build configuration from appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();
        }

        public static IBrowserFactory GetWebDriverFactory()
        {
            string browser = _configuration["Browser"];

            switch (browser.ToLower())
            {
                case Constants.Chrome:
                    return new ChromeFactory();
                case Constants.Firefox:
                    return new FirefoxFactory();
                default:
                    throw new ArgumentException("Invalid browser type");
            }
        }
    }

}
