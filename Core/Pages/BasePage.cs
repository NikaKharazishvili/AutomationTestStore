using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Core.Helpers;

namespace Core.Pages;

/// <summary>Abstract base class for all page objects. Provides shared WebDriver access, explicit waits, and common element interaction methods.</summary>
public abstract class BasePage
{
    protected readonly IWebDriver Driver;
    protected readonly WebDriverWait Wait;

    protected BasePage(IWebDriver driver, int timeoutSeconds = 10)
    {
        Driver = driver;
        Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
    }

    // Waits until element exists, is visible and enabled — handles stale elements gracefully
    protected IWebElement Find(string css)
    {
        LoggerHelper.Logger.Debug("Finding element: {Css}", css);
        return Wait.Until(_ =>
        {
            try
            {
                var element = Driver.FindElement(By.CssSelector(css));
                return element.Displayed && element.Enabled ? element : null;
            }
            catch (NoSuchElementException) { return null; }
            catch (StaleElementReferenceException) { return null; }
        });
    }

    // Find elements by css
    protected List<IWebElement> FindMany(string css)
    {
        LoggerHelper.Logger.Debug("Finding elements: {Css}", css);
        return Driver.FindElements(By.CssSelector(css)).ToList();
    }

    // Handles AJAX dependent dropdowns by retrying selection until option appears
    protected void SelectDropdownByText(IWebElement element, string text)
    {
        LoggerHelper.Logger.Debug("Selecting '{Text}' in dropdown", text);
        Wait.Until(_ =>
        {
            try
            {
                new SelectElement(element).SelectByText(text);
                return true;
            }
            catch (NoSuchElementException) { return false; }
            catch (StaleElementReferenceException) { return false; }
        });
    }
}