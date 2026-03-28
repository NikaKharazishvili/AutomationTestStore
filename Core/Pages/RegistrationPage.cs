using Core.Helpers;
using OpenQA.Selenium;

namespace Core.Pages;

/// <summary>Fills in the new account form and submits.</summary>
public class RegistrationPage : BasePage
{
    IWebElement FirstNameField => Find("#AccountFrm_firstname");
    IWebElement LastNameField => Find("#AccountFrm_lastname");
    IWebElement EmailField => Find("#AccountFrm_email");
    IWebElement TelephoneField => Find("#AccountFrm_telephone");
    IWebElement Address1Field => Find("#AccountFrm_address_1");
    IWebElement CityField => Find("#AccountFrm_city");
    IWebElement ZipCodeField => Find("#AccountFrm_postcode");
    IWebElement CountryDropdown => Find("#AccountFrm_country_id");
    IWebElement RegionDropdown => Find("#AccountFrm_zone_id");
    IWebElement LoginNameField => Find("#AccountFrm_loginname");
    IWebElement PasswordField => Find("#AccountFrm_password");
    IWebElement ConfirmPasswordField => Find("#AccountFrm_confirm");
    IWebElement NewsletterNoRadio => Find("#AccountFrm_newsletter0");
    IWebElement AgreeCheckbox => Find("#AccountFrm_agree");
    IWebElement ContinueButton => Find("#AccountFrm button[title='Continue']");
    IWebElement ErrorMessage => Find(".alert-error.alert-danger");

    public RegistrationPage(IWebDriver driver) : base(driver) { }

    public MyAccountPage Register(string firstName, string lastName, string email, string telephone, string address, string city, string zipCode, string country, string region, string loginName, string password)
    {
        LoggerHelper.Logger.Information("Filling registration form for {LoginName}", loginName);

        FirstNameField.SendKeys(firstName);
        LastNameField.SendKeys(lastName);
        EmailField.SendKeys(email);
        TelephoneField.SendKeys(telephone);

        Address1Field.SendKeys(address);
        CityField.SendKeys(city);
        ZipCodeField.SendKeys(zipCode);

        SelectDropdownByText(CountryDropdown, country);
        SelectDropdownByText(RegionDropdown, region);

        LoginNameField.SendKeys(loginName);
        PasswordField.SendKeys(password);
        ConfirmPasswordField.SendKeys(password);

        NewsletterNoRadio.Click();
        AgreeCheckbox.Click();
        ContinueButton.Click();

        return new MyAccountPage(Driver);
    }

    public RegistrationPage SubmitFormWithLoginName(string loginName)
    {
        LoggerHelper.Logger.Information("Submitting form with login name: {LoginName}", loginName);
        LoginNameField.SendKeys(loginName);
        AgreeCheckbox.Click();
        ContinueButton.Click();
        return this;
    }

    public string GetLoginNameErrorText()
    {
        LoggerHelper.Logger.Information("Getting Login name error message");
        return ErrorMessage.Text;
    }
}