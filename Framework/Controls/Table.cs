using Microsoft.Playwright;

namespace Aumentum.Framework.Pages
{
    public class Table : UITableElement
    {
        public Table(IPage page, ILocator locator) : base(page, locator)
        {
        }

        public Table(IFrameLocator frame, ILocator locator) : base(frame, locator)
        {
        }

        public ILocator Rows => Locator.Locator("tr");

        public ILocator Find(string criteria, int columnIndex)
        {   
            var cell = Rows.Locator(":scope", new() { HasText = criteria }).Locator("td:Nth-child(" + columnIndex + ")");            
            return cell;
        }

        public async Task Check(string criteria)
        {            
            await Rows.Locator(":scope", new() { HasText = criteria }).Locator(".a-checkbox").ClickAsync();
        }

        public async Task DeleteRow(string criteria)
        {   
            await Rows.Locator(":scope", new() { HasText = criteria }).Locator("[title='Delete']").ClickAsync();
        }
    }
}
