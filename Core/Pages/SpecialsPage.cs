using OpenQA.Selenium;
using Core.Helpers;

namespace Core.Pages;

/// <summary>Exposes the count of displayed new and old prices so tests can assert every product has a discount applied.</summary>
public class SpecialsPage : BasePage
{
    public SpecialsPage(IWebDriver driver) : base(driver) { }

    IReadOnlyList<IWebElement> NewPrices => FindMany(".price .pricenew").Where(e => e.Displayed).ToList();
    IReadOnlyList<IWebElement> OldPrices => FindMany(".price .priceold").Where(e => e.Displayed).ToList();

    public (int newPriceCount, int oldPriceCount) GetPriceCounts()
    {
        LoggerHelper.Logger.Information("Checking all products have discounts");
        LoggerHelper.Logger.Information("New prices count: {NewCount} | Old prices count: {OldCount}", NewPrices.Count, OldPrices.Count);
        return (NewPrices.Count, OldPrices.Count);
    }
}