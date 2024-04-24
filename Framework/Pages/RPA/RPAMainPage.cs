using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Aumentum.Framework.Pages
{
    public class RPAMainPage : BasePage
    {
        private IPage _page;

        public RPAMainPage(IPage page):base(page)
        {
            _page = page;
        }
        private ILocator AddNewLand => _page.GetByText("Add New");

        private ILocator AddNewBuilding => _page.Locator("#ctl00_ContentPlaceHolder_pvAppraisalSite_uc_pvBuildings_uc_dtgBuildingMain_ctl00_ctl02_ctl00_btnAddBuilding");

        public Table LegalPartyTable
        {
            get
            {
                return new Table(_page, _page.Locator("#ctl00_ContentPlaceHolder_pvAppraisalSite_uc_pvLand_uc_dtgLandMain_ctl00"));                
            }
        }

        public async Task GoTabAsync(string tab)
        {
            await _page.GetByRole(AriaRole.Link, new() { Name = tab }).ClickAsync();
        }

        public async Task GoSubTabAsync(string subTab)
        {
            await _page.GetByRole(AriaRole.Link, new() { Name = subTab, Exact = true }).ClickAsync();
        }
        
        public async Task<LandFrame> OpenNewLandAsync()
        {
            await AddNewLand.ClickAsync();
            var landFrame = new LandFrame(_page, _page.FrameLocator("//iframe[contains(@name,'ctl00_ContentPlaceHolder_RadWindowManager')]"));
            return landFrame;
        }

        public async Task<BuildingFrame> OpenNewBuildingAsync()
        {

            await AddNewBuilding.ClickAsync();
            var buildingFrame = new BuildingFrame(_page, _page.FrameLocator("//iframe[contains(@name,'ctl00_ContentPlaceHolder_RadWindowManager')]"));
            return buildingFrame;
        }

        internal async Task SaveAsync()
        {
            await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();
        }
    }
}