using Microsoft.Playwright;

namespace PlaywrightTests.Framework.Pages
{
    public class TableDropdown
    {
        private ILocator _dropdownLocator;
        private IPage _page;

        private IFrameLocator _frame;

        public TableDropdown(IPage page, ILocator locator)
        {
            _dropdownLocator = locator;
            _page = page;
        }

        public TableDropdown(IFrameLocator frame, ILocator locator)
        {
            _dropdownLocator = locator;
            _frame = frame;
        }

        public async Task SelectOptionFrame(string option)
        {   
            await _dropdownLocator.Locator("table input").ClickAsync();         
            await _frame.GetByText(option, new() { Exact = true }).ClickAsync();
        }
    }
}
