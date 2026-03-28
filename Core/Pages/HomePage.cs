using Core.Helpers;
using OpenQA.Selenium;

namespace Core.Pages;

/// <summary>Navigates to the home page and provides access to header navigation.</summary>
public class HomePage : BasePage
{
    IWebElement LoginRegisterLink => Find("#customer_menu_top li a");
    IWebElement ContinueNewCustomerButton => Find("#accountFrm fieldset button[title='Continue']");
    IWebElement SpecialsLink => Find("#main_menu_top > li:nth-child(1) > a > span");

    public HomePage(IWebDriver driver) : base(driver) { }

    public HomePage NavigateToUrl()
    {
        string url = ConfigReader.Get("BaseUrl");
        LoggerHelper.Logger.Information("Navigating to {Url}", url);
        Driver.Navigate().GoToUrl(url);
        return this;
    }

    public RegistrationPage GoToRegistration()
    {
        LoggerHelper.Logger.Information("Clicking on \"Login or register\"");
        LoginRegisterLink.Click();
        ContinueNewCustomerButton.Click();
        return new RegistrationPage(Driver);
    }

    public SpecialsPage GoToSpecials()
    {
        LoggerHelper.Logger.Information("Clicking on \"SPECIALS\"");
        SpecialsLink.Click();
        return new SpecialsPage(Driver);
    }
}