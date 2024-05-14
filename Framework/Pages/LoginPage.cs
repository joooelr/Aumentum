using Microsoft.Playwright;
namespace Aumentum.Framework.Pages
{
    public class LoginPage : BasePage
    {
        private IPage _page;

        public LoginPage(IPage page):base(page)
        {
            _page = page;
        }

        private ILocator Username => _page.Locator("#txtUserName");

        private ILocator Password => _page.Locator("#txtPassword");

        private ILocator BtnLogin => _page.Locator("#btnLogin");

        public async Task<HomePage> Login(string user, string password)
        {
            await Username.FillAsync(user);
            await Password.FillAsync(password);
            await BtnLogin.ClickAsync();
            var page = Aumentum.Framework.Pages.PageFactory.Create<HomePage>(_page);
            return page == null ? throw new Exception("Page is null") : page; 
        }
    }
}