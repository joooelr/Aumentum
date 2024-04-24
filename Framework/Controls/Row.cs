using Microsoft.Playwright;

namespace Aumentum.Framework.Pages
{
    public class Row : UITableElement
    {
        public Row(IPage page, ILocator locator) : base(page, locator)
        {
        }

        public Row(IFrameLocator frame, ILocator locator) : base(frame, locator)
        {
        }
    }
}
