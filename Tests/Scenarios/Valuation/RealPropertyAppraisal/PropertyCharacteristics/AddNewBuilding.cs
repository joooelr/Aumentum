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
public class PropertyCharacteristicsBuilding : PageTest
{
    [Test]
    public async Task AddNewBuilding()
    {
        var urlBase = Environment.GetEnvironmentVariable("URLDEV");
        var user = Environment.GetEnvironmentVariable("UserDev");
        var password = Environment.GetEnvironmentVariable("PasswordDev");
        Random rnd = new Random();
        var valueRand = rnd.Next(10, 30);
        var pin = "924350007";
        var buildingName = "Building" + valueRand;
        var improvementType = "Residential Garage";
        ///var shapeSizeType = "Very Irregular";
        var changeReason = "Information Correction/Update";
        var landLineMeassure = "Agricultural - Restricted LandLine 401 / 924350007";
        var improvementStyle = "Detached Garage - Single Family";
        var yearBuilt = "2019";
        var constructionClass = "Concrete / Masonry Bearing Walls (C)";
        var quality = "1.5";
        var condition = "Fair";

        await Page.SetViewportSizeAsync(1920, 1024);
        await Page.GotoAsync(urlBase);
        var loginPage = new LoginPage(Page);
        var homePage = await loginPage.Login(user, password);
        var httpPage = await homePage.NavigateTo<HttpPage>("Valuation > Property Characteristics");
        var  rpaMainPage = await httpPage.OpenPin(pin);
        
        ///if (rpaMainPage.UnlockExist().Result)
        //await rpaMainPage.Unlock();
            
        await rpaMainPage.GoTabAsync("Appraisal Site");
        await rpaMainPage.GoSubTabAsync("Buildings");
        var  buildingFrame = await rpaMainPage.OpenNewBuildingAsync();
        await buildingFrame.BuildingName.FillAsync(buildingName);
        await buildingFrame.ChangeReason.SelectOptionFrameAsync(changeReason);        
        await buildingFrame.ImprovementType.SelectOptionFrameAsync(improvementType);        
        //await buildingFrame.ShapeSizeType.SelectOptionFrameAsync(shapeSizeType);
        await buildingFrame.AddNewRelatedLandLinesButton.ClickAsync();
        await buildingFrame.LandLine.SelectOptionFrameAsync(landLineMeassure);    
        await buildingFrame.NextButton.ClickAsync();

        await buildingFrame.ImprovementStyle.SelectOptionFrameAsync(improvementStyle);
        await buildingFrame.YearBuilt.FillAsync(yearBuilt);
        await buildingFrame.ConstructionClass.SelectOptionFrameAsync(constructionClass);                
        await buildingFrame.Condition.SelectOptionFrameAsync(condition); 
        await buildingFrame.Quality.SelectOptionFrameAsync(quality);
               
        var selectTrackingTypeFrame = await buildingFrame.AddNewSectionDetail();
        await selectTrackingTypeFrame.FloorAndUse.ClickAsync();
        await selectTrackingTypeFrame.OKButton.ClickAsync();

        await buildingFrame.FloorType.SelectOptionFrame("Ground");
        await buildingFrame.SectionOccupancy.SelectOptionFrame("Ground");
        await buildingFrame.SectionYearBuilt.FillAsync("2019");
        await buildingFrame.GarageArea.FillAsync("2");
        ///await Page.PauseAsync();                
        await Page.PauseAsync();
        
 //  await Expect(rpaMainPage.LegalPartyTable.Find(landName, 6)).ToHaveTextAsync(landType);
 //  await Expect(rpaMainPage.LegalPartyTable.Find(landName, 8)).ToHaveTextAsync(unitOfMeasure);
 //  await rpaMainPage.Save();
 //  await rpaMainPage.PerformAction<HomePage>("Close");

////await page.FrameLocator("iframe[name=\"ctl00_ContentPlaceHolder_RadWindowManager11713926457628\"]").GetByRole(AriaRole.Row, new() { Name = "Related Land Lines Add New" }).Locator("span").Nth(1).ClickAsync();


 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgRelated_ctl00_ctl02_ctl00_btnAdd").GetByText("Add New").ClickAsync();
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgRelated_ctl00_ctl04_cbLandLine_Arrow").ClickAsync();
 // await buildingFrame.GetByText("Agricultural - Restricted LandLine 401 /").ClickAsync();
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_cbApprChangeReasonCode_Arrow").ClickAsync();
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_cbApprChangeReasonCode_DropDown").GetByText("New Construction", new() { Exact = true }).ClickAsync();
 // await buildingFrame.GetByRole(AriaRole.Button, new() { Name = "Next" }).ClickAsync();
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_txtYearBuilt").ClickAsync();
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_txtYearBuilt").FillAsync("2022");
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_txtYearBuilt").PressAsync("Tab");
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_cbConstructionClass_Input").ClickAsync();
 // await buildingFrame.GetByText("Mill Type (M)").ClickAsync();
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_cbQuality_Arrow").ClickAsync();
 // await buildingFrame.GetByText("0.5").ClickAsync();
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_cbCondition_Arrow").ClickAsync();
 // await buildingFrame.GetByText("Good").ClickAsync();
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgUses_ctl00_ctl02_ctl00_btnAddUse").GetByText("Add New").ClickAsync();
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_btnFloor span").First.ClickAsync();
 // await buildingFrame.GetByRole(AriaRole.Button, new() { Name = "OK" }).ClickAsync();
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgFloors_ctl00_ctl04_cbFloorType_Input").ClickAsync();
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgFloors_ctl00_ctl04_cbUseCode_Arrow").ClickAsync();
 // await buildingFrame.GetByText("Bank Barn, General Purpose").ClickAsync();
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgFloors_ctl00_ctl04_TB_EffectiveYearBuilt").ClickAsync();
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgFloors_ctl00_ctl04_TB_EffectiveYearBuilt").FillAsync("2022");
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgFloors_ctl00_ctl04_TB_YearRemodeled").ClickAsync();
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgUseSizes_ctl00_ctl07_txtSize").ClickAsync();
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgUseSizes_ctl00_ctl07_txtSize").FillAsync("2");
 // await buildingFrame.Locator("body").ClickAsync();
 // await buildingFrame.GetByRole(AriaRole.Button, new() { Name = "Finish" }).ClickAsync();
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgUseSizes_ctl00_ctl09_txtSize").ClickAsync();
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgUseSizes_ctl00_ctl09_txtSize").FillAsync("2");
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgUseSizes_ctl00_ctl10_txtSize").ClickAsync();
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgUseSizes_ctl00_ctl10_txtSize").FillAsync("2");
 // await buildingFrame.Locator("#RAD_SPLITTER_PANE_CONTENT_ctl00_ContentPlaceHolder_ucChildEdit_rpBuildingDetailEditBottom").ClickAsync();
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgUseSizes_ctl00_ctl11_txtSize").ClickAsync();
 // await buildingFrame.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgUseSizes_ctl00_ctl11_txtSize").FillAsync("2");
 // await buildingFrame.Locator("#RAD_SPLITTER_PANE_CONTENT_ctl00_ContentPlaceHolder_ucChildEdit_rpBuildingDetailEditBottom").ClickAsync();
 // await page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();
 // await page.GetByText("Close", new() { Exact = true }).ClickAsync();

    }
}

