using Microsoft.Playwright;

namespace PlaywrightTests.Framework.Pages
{
    public class Dropdown
    {
        private ILocator _dropdownLocator;
        private IPage _page;

        private IFrameLocator _frame;

        public Dropdown(IPage page, ILocator locator)
        {
            _dropdownLocator = locator;
            _page = page;
        }

        public Dropdown(IFrameLocator frame, ILocator locator)
        {
            _dropdownLocator = locator;
            _frame = frame;
        }

        public async Task SelectOptionFrame(string option)
        {   
            await _dropdownLocator.Locator("a").ClickAsync();         
            await _frame.GetByText(option, new() { Exact = true }).ClickAsync();
        }
    }
}
