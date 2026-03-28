using Core.Drivers;
using Core.Pages;
using FluentAssertions;

namespace Tests.UseCases;

/// <summary>UC-3: Verifies that all 'displayed' products on the Special Offers page have a discount applied.</summary>
public class UC3_SpecialOffersTest : BaseTest
{
    [Theory]
    [InlineData(BrowserType.Chrome)]
    [InlineData(BrowserType.Firefox)]
    public void AllProductsDisplayedShouldHaveDiscount(BrowserType browser)
    {
        var driver = CreateDriver(browser);
        var priceCounts = new HomePage(driver)
            .NavigateToUrl()
            .GoToSpecials()
            .GetPriceCounts();

        priceCounts.newPriceCount.Should().Be(priceCounts.oldPriceCount);
    }
}