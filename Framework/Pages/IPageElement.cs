using Microsoft.Playwright;

namespace Aumentum.Framework.Pages
{
    public interface IPageElement
    {
        public ILocator Locator { get; }
        public IPage Page { get; }
        public IFrameLocator Frame { get; }
    }
}