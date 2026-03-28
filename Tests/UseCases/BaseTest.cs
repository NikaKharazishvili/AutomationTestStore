using Core.Drivers;
using OpenQA.Selenium;

namespace Tests.UseCases;

/// <summary>Base class for all tests. Creates a fresh driver per test method and disposes it after, enabling parallel multi-browser execution.</summary>
public abstract class BaseTest : IDisposable
{
    IWebDriver? _driver;

    protected IWebDriver CreateDriver(BrowserType browser)
    {
        _driver = DriverFactory.CreateDriver(browser);
        return _driver;
    }

    public void Dispose()
    {
        _driver?.Quit();
        _driver?.Dispose();
    }

    protected static string RandomChar => Guid.NewGuid().ToString("N")[..6];
}