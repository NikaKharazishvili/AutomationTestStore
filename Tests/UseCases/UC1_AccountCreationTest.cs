using Core.Drivers;
using Core.Pages;
using Core.Helpers;
using FluentAssertions;

namespace Tests.UseCases;

/// <summary>UC-1: Tests successful creation of a new account and verifies login state.</summary>
public class UC1_AccountCreationTest : BaseTest
{
    [Theory]
    [InlineData(BrowserType.Chrome)]
    [InlineData(BrowserType.Firefox)]
    public void ShouldCreateAccountAndBeLoggedIn(BrowserType browser)
    {
        // Append random suffix to avoid "already registered" conflicts on repeated test runs
        var loginName = ConfigReader.Get("User:LoginName") + RandomChar;
        var email = ConfigReader.Get("User:Email").Replace("@", $"{RandomChar}@");

        var driver = CreateDriver(browser);
        var accountPage = new HomePage(driver)
            .NavigateToUrl()
            .GoToRegistration()
            .Register(
                ConfigReader.Get("User:FirstName"),
                ConfigReader.Get("User:LastName"),
                email,
                ConfigReader.Get("User:Telephone"),
                ConfigReader.Get("User:Address1"),
                ConfigReader.Get("User:City"),
                ConfigReader.Get("User:ZipCode"),
                ConfigReader.Get("User:Country"),
                ConfigReader.Get("User:Region"),
                loginName,
                ConfigReader.Get("User:Password"));

        accountPage.AccountHeadingText.Should().Contain("MY ACCOUNT");
        accountPage.WelcomeMessageText.Should().Contain($"Welcome back {ConfigReader.Get("User:FirstName")}");
    }
}