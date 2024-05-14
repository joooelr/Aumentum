using Microsoft.Playwright;
using System;
using System.Collections.Generic;

namespace Aumentum.Framework.Pages
{
    public interface IPageElement
    {
        public ILocator Locator { get; }
        public IPage Page { get; }
        public IFrameLocator Frame { get; }
    }
}