using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Aumentum.Framework.Pages;
using NUnit.Framework;
using System;
using System.Threading.Channels;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public partial class PropertyCharacteristicsLand : PageTest
{
    [Test]
    public async Task AddingNewLand()
    {
        var urlBase = Environment.GetEnvironmentVariable("URLDEV");
        var user = Environment.GetEnvironmentVariable("UserDev");
        var password = Environment.GetEnvironmentVariable("PasswordDev");
        Random rnd = new Random();
        var valueRand = rnd.Next(10, 30);
        var pin = "009000001";
        var landType = "Residential";
        var landName = "Test" + valueRand;
        var topography = "Flat to mild (0-5 degree slope)";
        var zoning = "Single-Family Dwellings";
        var siteRating = "Excellent";
        var sizeType = "* Acres";
        var sizeValue = "2";
        var unitOfMeasure = "Acres";
        var changeReason = "Information Correction/Update";

        await Page.GotoAsync(urlBase);
        var loginPage = new LoginPage(Page);
        var homePage = await loginPage.Login(user, password);
        var httpPage = await homePage.NavigateTo<HttpPage>("Valuation > Property Characteristics");
        var  rpaMainPage = await httpPage.OpenPin(pin);
        await rpaMainPage.GoTabAsync("Appraisal Site");
        await rpaMainPage.GoSubTabAsync("Land");
        var landFrame = await rpaMainPage.OpenNewLandAsync();
        await landFrame.LandName.FillAsync(landName);
        await landFrame.LandType.SelectOptionFrame(landType);
        await landFrame.Topography.SelectOptionFrame(topography);
        await landFrame.Zoning.SelectOptionFrame(zoning);
        await landFrame.SiteRating.SelectOptionFrame(siteRating);
        await landFrame.AddNew();
        await landFrame.SizeType.SelectOptionFrame(sizeType);
        await landFrame.SizeValue.FillAsync(sizeValue);       
        await landFrame.UnitOfMeasure.SelectOptionFrame(unitOfMeasure);
        await landFrame.InsertButton.ClickAsync();
        await landFrame.ChangeReason.SelectOptionFrame(changeReason);
        await landFrame.OK();
        await Expect(rpaMainPage.LegalPartyTable.Find(landName, 6)).ToHaveTextAsync(landType);
        await Expect(rpaMainPage.LegalPartyTable.Find(landName, 8)).ToHaveTextAsync(unitOfMeasure);
        await rpaMainPage.SaveAsync();
        await rpaMainPage.LegalPartyTable.DeleteRow(landName);
        var confirmDeletionFrame = rpaMainPage.ConfirmDeletionFrame;
        await confirmDeletionFrame.ChangeReason.SelectOptionFrame(changeReason);
        await confirmDeletionFrame.OK();
        await rpaMainPage.PerformAction<HomePage>("Close");
    }
}

