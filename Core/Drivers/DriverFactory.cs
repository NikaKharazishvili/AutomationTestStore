using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Core.Helpers;

namespace Core.Drivers;

public enum BrowserType { Chrome, Firefox }

/// <summary>Factory method pattern implementation. Creates and configures a WebDriver instance for the specified browser type.</summary>
public static class DriverFactory
{
    public static IWebDriver CreateDriver(BrowserType browser)
    {
        LoggerHelper.Logger.Information("Creating {Browser} driver", browser);
        bool headless = bool.Parse(ConfigReader.Get("Headless"));

        if (browser == BrowserType.Chrome)
        {
            var options = new ChromeOptions();
            options.AddArguments("--window-size=1920,1080");
            if (headless) options.AddArguments("--headless=new");
            return new ChromeDriver(options);
        }
        else if (browser == BrowserType.Firefox)
        {
            var options = new FirefoxOptions();
            options.AddArguments("--width=1920", "--height=1080");
            if (headless) options.AddArguments("--headless");
            return new FirefoxDriver(options);
        }
        throw new ArgumentOutOfRangeException(nameof(browser), "Browser not supported");
    }
}