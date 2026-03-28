using OpenQA.Selenium;
using Core.Helpers;

namespace Core.Pages;

/// <summary>Exposes account info for post-registration assertions.</summary>
public class MyAccountPage : BasePage
{
    IWebElement AccountHeading => Find("div.sidewidt h2 span");
    IWebElement WelcomeMessage => Find("#customer_menu_top li a div");

    public MyAccountPage(IWebDriver driver) : base(driver) { }

    public string AccountHeadingText
    {
        get
        {
            LoggerHelper.Logger.Information("Getting account heading text");
            return AccountHeading.Text;
        }
    }

    public string WelcomeMessageText
    {
        get
        {
            LoggerHelper.Logger.Information("Getting welcome message text");
            return WelcomeMessage.Text;
        }
    }
}