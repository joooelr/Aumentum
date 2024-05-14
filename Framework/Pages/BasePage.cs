using Aumentum.Framework.Pages;
using Microsoft.Playwright;

namespace Aumentum.Framework.Pages
{
    public class BasePage : IAumentumPage
    {
        private string location = string.Empty;
        private IPage _page;

        public BasePage(IPage page)
        {
            _page = page;
        }

        public virtual Task<T> NavigateTo<T>(string path) where T : IAumentumPage
        {                      
            var items = path.Split(new[] { " > " }, StringSplitOptions.None).Select(i => i.Trim()).ToList();
            foreach (var i in items)
            {
                _page.GetByRole(AriaRole.Link, new() { Name = i }).ClickAsync();
            }
            
            var page = PageFactory.Create<T>(_page);            
            _page.WaitForLoadStateAsync();
            return page == null ? throw new Exception("Page is null") : Task.FromResult(page);
        }  

        public virtual Task<T> PerformAction<T>(string actionName) where T : IAumentumPage
        {
            _page.GetByRole(AriaRole.Table, new() { Name = actionName }).ClickAsync();
            var page = PageFactory.Create<T>(_page);
            return page == null ? throw new Exception("Page is null") : Task.FromResult(page);
        }
    }
}