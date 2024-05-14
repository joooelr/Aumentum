using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Aumentum.Framework.Pages
{
    public class ConfirmDeletionFrame
    {
        private IPage _page;
        private IFrameLocator _frameLocator;
        public ConfirmDeletionFrame(IPage page, IFrameLocator locator)
        {
            _page = page;
            _frameLocator = locator;            
        }

        public Dropdown ChangeReason => new Dropdown(_frameLocator, _frameLocator.Locator("#ctl00_ContentPlaceHolder_cbApprChangeReasonCode"));        
        
        public ILocator OKButton => _frameLocator.GetByRole(AriaRole.Button, new() { Name = "OK" });
        
        public async Task OK()
        {
            await OKButton.ClickAsync();
        }
    }
}
