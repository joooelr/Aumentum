using Aumentum.Framework.Pages;
using Microsoft.Playwright;

namespace Aumentum.Framework
{
    public class Application 
    {
        public async Task<LoginPage> Open()
        {
            var urlBase = Environment.GetEnvironmentVariable("URLDEV");
            var loginUrl = urlBase + "/login.aspx";

            var playwright = await Playwright.CreateAsync();
            var chromium = playwright.Firefox;
            var browser = await chromium.LaunchAsync(new BrowserTypeLaunchOptions {Headless = false, SlowMo = 50,});
            var page = await browser.NewPageAsync();
            await page.GotoAsync(loginUrl);

            var loginPage = PageFactory.Create<LoginPage>(page);      
            return loginPage == null ? throw new Exception("Page is null") : loginPage;
        }
    }
}