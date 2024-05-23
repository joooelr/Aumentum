using Microsoft.Playwright;

namespace Aumentum.Framework.Pages
{
    public class Dropdown : UITableElement
    {
        public Dropdown(IPage page, ILocator locator) : base(page, locator)
        {
        }

        public Dropdown(IFrameLocator frame, ILocator locator) : base(frame, locator)
        {
        }

        public async Task SelectOptionFrameAsync(string option, int timeout = 3000)
        {   
            await Locator.Locator("a").ClickAsync();         
            await Frame.GetByText(option, new() { Exact = true }).ClickAsync(new() { 
                Timeout = timeout
            });
        }
    }
}