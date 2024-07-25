using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumWithCucumber.BrowserFactoryPattern;
using TechTalk.SpecFlow;

namespace SeleniumWithCucumber
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private static readonly ILog Log = LogManager.GetLogger(typeof(LoginSteps));

        [Given(@"user navigate to login page on Browser ""(.*)""")]
        public void GivenIAmOnTheLoginPage(string browser)
        {
            IBrowserFactory factory = WebDriverFactoryProvider.GetWebDriverFactory();
            driver = factory.CreateDriver();

            Log.Info("Navigating to the login page.");
            driver.Navigate().GoToUrl(Constants.BaseUrl);
            driver.Manage().Window.Maximize();
            loginPage = new LoginPage(driver);
        }

        [When(@"user enter valid username ""(.*)"" and password ""(.*)""")]
        public void WhenIEnterValidCredentials(string username, string password)
        {
            Log.Info("Entering valid username and password.");
            loginPage.SetUsername(username);
            loginPage.SetPassword(password);
        }

        [When(@"user selects the login button")]
        public void WhenIClickTheLoginButton()
        {

            Log.Info("Clicking the login button.");
            loginPage.ClickLogin();
        }

        [Then(@"DashboardPage should display")]
        public void ThenIShouldSeeTheDashboardpage()
        {
            try
            {
                Log.Info("Verifying the dashboard is displayed.");
                Assert.That(driver.Url.Contains("dashboard"), $"The text '{"dashboard"}' was not found on the page.");
                Assert.That(driver.Title.Contains(Constants.OrangeHRM_Title));
            }
            catch (AssertionException ex)
            {
                Log.Error($"Assertion failed: {ex.Message}");
                ScreenshotHelper.TakeScreenshot(driver, "FailedTest_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                throw;
            }
        }

        [AfterScenario]
        public void CleanupWebDriver()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                ScreenshotHelper.TakeScreenshot(driver, "FailedTest_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
            }

            driver.Quit();
            driver.Dispose();
        }
    }
}
