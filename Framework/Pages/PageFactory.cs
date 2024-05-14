using System;
using Microsoft.Playwright;
using Aumentum.Framework.Pages;

namespace Aumentum.Framework.Pages
{
    public static class PageFactory
    {
        public static T? Create<T>(IPage page) where T : IAumentumPage
        {
            return (T?)Activator.CreateInstance(typeof(T), page);
        }       
    }
}