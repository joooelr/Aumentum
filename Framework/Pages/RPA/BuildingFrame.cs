using System.Threading.Tasks;
using Microsoft.Playwright;
using Aumentum.Framework;

namespace Aumentum.Framework.Pages
{
    public class BuildingFrame
    {
        private IPage _page;
        private IFrameLocator _frameLocator;
        public BuildingFrame(IPage page, IFrameLocator locator)
        {
            _page = page;
            _frameLocator = locator;            
        }

        public ILocator BuildingName => _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_txtBuildingName");

        public Dropdown ImprovementType => new Dropdown(_frameLocator, _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_cbImprovementType"));

        public Dropdown ShapeSizeType => new Dropdown(_frameLocator, _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_cbShapeSizeType"));

        public Dropdown LandLine => new Dropdown(_frameLocator, _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgRelated_ctl00_ctl04_cbLandLine"));

        public ILocator YearBuilt => _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_txtYearBuilt");

        public Dropdown ConstructionClass => new Dropdown(_frameLocator, _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_cbConstructionClass"));

        public Dropdown Quality => new Dropdown(_frameLocator, _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_cbQuality"));

        public Dropdown Condition => new Dropdown(_frameLocator, _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_cbCondition"));

        public Dropdown ChangeReason => new Dropdown(_frameLocator, _frameLocator.Locator("#ctl00_ContentPlaceHolder_cbApprChangeReasonCode"));
        
        public ILocator AddNewButton => _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgRelated_ctl00_ctl02_ctl00_btnAdd").GetByText("Add New");        

        public ILocator NextButton => _frameLocator.GetByRole(AriaRole.Button, new() { Name = "Next" });      
        
        public ILocator AddNewSectionDetailButton => _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgUses_ctl00_ctl02_ctl00_btnAddUse");   
        
        public ILocator FloorButton => _frameLocator.Locator("#ctl00_ContentPlaceHolder_btnFloor span").First;  

        public Dropdown UseCode => new Dropdown(_frameLocator, _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgFloors_ctl00_ctl04_cbUseCode"));

        public ILocator EffectiveYearBuilt => _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgFloors_ctl00_ctl04_TB_EffectiveYearBuilt");

        public ILocator AddNewRelatedLandLinesButton => _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgRelated_ctl00_ctl02_ctl00_btnAdd");

        public Dropdown ImprovementStyle => new Dropdown(_frameLocator, _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_cbImprovementStyle"));

        public Task SelectTrackingTypeFrame { get; internal set; }

        public TableDropdown FloorType => new TableDropdown(_frameLocator, _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgFloors_ctl00_ctl04_cbFloorType"));
        
        public TableDropdown SectionOccupancy => new TableDropdown(_frameLocator, _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgFloors_ctl00_ctl04_cbUseCode"));
        
        public TableDropdown SectionCondition => new TableDropdown(_frameLocator, _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgFloors_ctl00_ctl04_cbFloorUseCondition"));
        
        public ILocator SectionYearBuilt => _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgFloors_ctl00_ctl04_TB_EffectiveYearBuilt");
        
        public ILocator GarageArea => _frameLocator.Locator("#ctl00_ContentPlaceHolder_ucChildEdit_dtgUseSizes_ctl00_ctl08_txtSize");
        
        public async Task AddNew() => await _frameLocator.GetByRole(AriaRole.Cell, new() { Name = "Add New", Exact = true }).Locator("span").Nth(1).ClickAsync();

        public async Task Finish()
        {
            await _frameLocator.Locator("#ctl00_ContentPlaceHolder_btnOK").ClickAsync(); 
        }
        
        public async Task<SelectTrackingTypeFrame> AddNewSectionDetail()
        {
            await AddNewSectionDetailButton.ClickAsync();
            return new SelectTrackingTypeFrame(_page, _page.FrameLocator("//iframe[contains(@src,'RPA/AppraisalSite/Buildings/BuildingDetailEditAddFloorOccDialog.aspx')]"));
        }
    }
}
