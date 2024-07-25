namespace SeleniumWithCucumber
{
    internal class Constants
    {
        // Base URL for the application
        public const string BaseUrl = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";

        // Set the path to the Gecko Driver Path
        public const string geckoDriverPath = @"D:\Automation Learning Projects\SpecFlowProject1\Driver\GeckoDriver\geckodriver.exe";
        // Set the path to the Firefox binary
        public const string firefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe"; // Specify the correct path to the Firefox executable

        public const string OrangeHRM_Title = "OrangeHRM";
        public const string Chrome = "chrome";
        public const string Firefox = "firefox";

        // User credentials
        public static class Credentials
        {       
        public const string Username = "Admin";
        public const string Password = "admin123";
        }
    }
}
