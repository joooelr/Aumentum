using Microsoft.Playwright;
using System;
using System.Collections.Generic;
namespace Aumentum.Framework.Pages
{
    public abstract class UITableElement : IPageElement
    {
        public ILocator Locator { get; }
        public IPage Page { get; }
        public IFrameLocator Frame { get; }

        protected UITableElement(IPage page, ILocator locator)
        {
            Locator = locator;
            Page = page;
        }

        protected UITableElement(IFrameLocator frame, ILocator locator)
        {
            Locator = locator;
            Frame = frame;
        }
    }
}