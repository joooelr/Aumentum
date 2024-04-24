using Microsoft.Playwright;

namespace Aumentum.Framework.Pages
{
    public class TableDropdown : UITableElement
    {
        public TableDropdown(IPage page, ILocator locator) : base(page, locator)
        {
        }

        public TableDropdown(IFrameLocator frame, ILocator locator) : base(frame, locator)
        {
        }

        public async Task SelectOptionFrame(string option)
        {   
            await Locator.Locator("table input").ClickAsync();         
            await Frame.GetByText(option, new() { Exact = true }).ClickAsync();
        }
    }
}
