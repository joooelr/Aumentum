using System.Threading.Tasks;
using Aumentum.Framework.Pages;
using Microsoft.Playwright;

namespace PlaywrightTests.Framework.Pages
{
    public class HomePage : BasePage
    {
        private IPage _page;

        public HomePage(IPage page):base(page)
        {
            _page = page;
        }
    }
}