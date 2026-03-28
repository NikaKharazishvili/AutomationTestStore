using Core.Drivers;
using Core.Pages;
using FluentAssertions;

namespace Tests.UseCases;

/// <summary>UC-2: Tests validation messages on Registration form (data-driven ready, reuses HomePage).</summary>
public class UC2_ValidationMessagesTest : BaseTest
{
    const string ExpectedError = "Login name must be alphanumeric only and between 5 and 64 characters!";

    [Theory]
    [InlineData(BrowserType.Chrome, "")] // Too short (Empty)
    [InlineData(BrowserType.Firefox, "")] // Too short (Empty)
    [InlineData(BrowserType.Chrome, "abcdefghij1234567890abcdefghij1234567890abcdefghij1234567890abcde")] // Too long (65 chars)
    [InlineData(BrowserType.Firefox, "abcdefghij1234567890abcdefghij1234567890abcdefghij1234567890abcde")] // Too long (65 chars)
    [InlineData(BrowserType.Chrome, "hello!")] // Non-alphanumeric
    [InlineData(BrowserType.Firefox, "hello!")] // Non-alphanumeric
    public void ShouldDisplayLoginNameErrorForOutOfRange(BrowserType browser, string loginName)
    {
        var driver = CreateDriver(browser);
        new HomePage(driver)
            .NavigateToUrl()
            .GoToRegistration()
            .SubmitFormWithLoginName(loginName)
            .GetLoginNameErrorText()
            .Should().Contain(ExpectedError);
    }
}