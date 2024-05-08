using Microsoft.Playwright;
namespace Aumentum.Framework.Pages
{
    public abstract class UITableElement : IPageElement
    {
        public ILocator Locator { get; }
        public IPage Page { get; }
        public IFrameLocator Frame { get; }

        protected UITableElement(IPage? page, ILocator locator)
        {            
            Page = page;
            Locator = locator;
        }

        protected UITableElement(IFrameLocator frame, ILocator locator)
        {
            Locator = locator;
            Frame = frame;
        }        
    }
}