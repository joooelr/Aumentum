using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Aumentum.Framework.Pages
{
    public class LandFrame
    {
        private IPage _page;
        private IFrameLocator _frameLocator;
        public LandFrame(IPage page, IFrameLocator locator)
        {
            _page = page;
            _frameLocator = locator;            
        }

        public ILocator LandName => _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_tbLandName");

        public Dropdown LandType => new Dropdown(_frameLocator, _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_cbLandType"));

        public Dropdown Topography => new Dropdown(_frameLocator, _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_cbTopography"));

        public Dropdown Zoning => new Dropdown(_frameLocator, _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_cbZoning"));

        public Dropdown SiteRating => new Dropdown(_frameLocator, _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_cbSiteRating"));

        public TableDropdown SizeType => new TableDropdown(_frameLocator, _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgLandSizes_ctl00_ctl02_ctl02_cbSizeType"));

        public ILocator SizeValue => _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgLandSizes_ctl00_ctl02_ctl02_txtSizeValue");

        public TableDropdown UnitOfMeasure => new TableDropdown(_frameLocator, _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgLandSizes_ctl00_ctl02_ctl02_cbUnitOfMeasure"));
        
        public ILocator InsertButton => _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgLandSizes_ctl00_ctl02_ctl02_btnInsert");

        public Dropdown ChangeReason => new Dropdown(_frameLocator, _frameLocator.Locator("#ctl00_ContentPlaceHolder_divChangeReason"));
        
        public ILocator OKButton => _frameLocator.GetByRole(AriaRole.Button, new() { Name = "OK" });

        public async Task AddNew() => await _frameLocator.GetByRole(AriaRole.Cell, new() { Name = "Add New", Exact = true }).Locator("span").Nth(1).ClickAsync();

        public async Task OK()
        {
            await _frameLocator.GetByRole(AriaRole.Button, new() { Name = "OK" }).ClickAsync(); 
        }
    }
}
