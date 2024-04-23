using Microsoft.Playwright;

namespace PlaywrightTests.Framework.Pages
{
    public class Table
    {        

        private IEnumerable<string> _footers;
        public ILocator _tableLocator;
        private IPage _page;     

        private IFrameLocator _frame;

        public Table(IPage page, ILocator tableLocator)
        {
            _tableLocator = tableLocator;
            _page = page;
        }

        public Table(IFrameLocator frame, ILocator tableLocator)
        {
            _tableLocator = tableLocator;
            _frame = frame;
        }

        public ILocator Rows => _tableLocator.Locator("tr");

        public ILocator Find(string criteria, int columnIndex)
        {   
            var cell = Rows.Locator(":scope", new() { HasText = criteria }).Locator("td:Nth-child(" + columnIndex + ")");            
            return cell;
        }

        public async Task Check(string criteria)
        {            
            await Rows.Locator(":scope", new() { HasText = criteria }).Locator(".a-checkbox").ClickAsync();
        }
    }
}
