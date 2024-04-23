using Microsoft.Playwright;

namespace PlaywrightTests.Framework.Pages
{
    public class Row
    {
 
        private ILocator _rowLocator;
        private IPage _page;     
        private IFrameLocator _frame;

        public Row(IPage page, ILocator rowLocator)
        {
            _rowLocator = rowLocator;
            _page = page;
        }

        public Row(IFrameLocator frame, ILocator rowLocator)
        {
            _rowLocator = rowLocator;
            _frame = frame;
        }
    }
}
