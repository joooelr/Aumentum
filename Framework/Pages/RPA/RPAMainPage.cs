using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTests.Framework.Pages
{
    public class RPAMainPage : BasePage
    {
        private IPage _page;

        public RPAMainPage(IPage page):base(page)
        {
            _page = page;
        }
        private ILocator AddNewLand => _page.GetByText("Add New");

        public Table LegalPartyTable
        {
            get
            {
                return new Table(_page, _page.Locator("#ctl00_ContentPlaceHolder_pvAppraisalSite_uc_pvLand_uc_dtgLandMain_ctl00"));                
            }
        }

        public async Task GoTab(string tab)
        {
            await _page.GetByRole(AriaRole.Link, new() { Name = tab }).ClickAsync();
        }

        public async Task GoSubTab(string subTab)
        {
            await _page.GetByRole(AriaRole.Link, new() { Name = subTab, Exact = true }).ClickAsync();
        }
        
        public async Task<LandFrame> OpenNewLand()
        {

            await AddNewLand.ClickAsync();
            var landFrame = new LandFrame(_page, _page.FrameLocator("//iframe[contains(@name,'ctl00_ContentPlaceHolder_RadWindowManager')]"));
            return landFrame;
        }

        internal async Task Save()
        {
            await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();
        }
    }
}