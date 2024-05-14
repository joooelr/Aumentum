using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Aumentum.Framework.Pages
{
    public class HttpPage : BasePage
    {
        private IPage _page;

        public HttpPage(IPage page):base(page)
        {
            _page = page;
        }

        private ILocator SimpleSearchButton => _page.Locator("#simplesearch");
        private ILocator SimpleSearch => _page.Locator("#simplesearch");
        private ILocator SearchButton => _page.GetByRole(AriaRole.Button, new() { Name = "Search" });
        private ILocator NextButton => _page.GetByText("Next");
        private Table ResultsTable => new Table(_page, _page.Locator("#results"));
        
       public async Task<RPAMainPage> OpenPin(string pin)
       {
            await SimpleSearchButton.ClickAsync();
            await SimpleSearch.FillAsync(pin);
            await SearchButton.ClickAsync();
            await ResultsTable.Check(pin);
            await NextButton.ClickAsync();
            _page.WaitForLoadStateAsync();
            var page = PageFactory.Create<RPAMainPage>(_page);
            return page == null ? throw new Exception("Page is null") : page;
       }       
    }
}