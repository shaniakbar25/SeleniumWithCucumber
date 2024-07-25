using OpenQA.Selenium;
using System;
using System.IO;

public static class ScreenshotHelper
{
    public static void TakeScreenshot(IWebDriver driver, string fileName)
    {
        try
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, $"{fileName}.png");
            screenshot.SaveAsFile(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error taking screenshot: " + ex.Message);
        }
    }
}
