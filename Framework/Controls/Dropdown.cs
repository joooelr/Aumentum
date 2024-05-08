using Microsoft.Playwright;
using static System.Net.Mime.MediaTypeNames;

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

        public async Task SelectOptionFrameAsync(string option, int timeout=3000)
        {   
            await Locator.Locator("a").ClickAsync();
            await Frame.GetByText(option, new() { Exact = true }).ClickAsync(new() { 
                Timeout= timeout
            });
        }

        public async Task SelectOptionFrameAlternateAsync(string option)
        {
            await Locator.Locator("a").ClickAsync();
            await this.Page
                .FrameLocator("//iframe[contains(@name,'ctl00_ContentPlaceHolder_RadWindowManager')]")
                .Locator($"//form[@id='aspnetForm']//*[contains(@style,'visible')]//ul[@class='rcbList']/li[text()='{option}']")
                .ClickAsync();        
        }
    }
}
