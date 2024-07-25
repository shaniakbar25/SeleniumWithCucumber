using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace SeleniumWithCucumber.BrowserFactoryPattern
{
    public interface IBrowserFactory
    {
        IWebDriver CreateDriver();
    }

    public class ChromeFactory : IBrowserFactory
    {
        public IWebDriver CreateDriver()
        {
            return new ChromeDriver();
        }
    }

    public class FirefoxFactory : IBrowserFactory
    {
        public IWebDriver CreateDriver()
        {

            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(Constants.geckoDriverPath);
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = Constants.firefoxBinaryPath;

            return new FirefoxDriver(service, options);
        }
    }

}
