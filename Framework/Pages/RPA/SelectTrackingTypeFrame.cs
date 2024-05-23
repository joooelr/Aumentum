using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Aumentum.Framework.Pages
{
    public class SelectTrackingTypeFrame
    {
        private IPage _page;
        private IFrameLocator _frameLocator;
        public SelectTrackingTypeFrame(IPage page, IFrameLocator locator)
        {
            _page = page;
            _frameLocator = locator;            
        }

        public ILocator UseOnly => _frameLocator.Locator("#ctl00_ContentPlaceHolder_btnUse > span.rbPrimaryIcon.rbToggleRadio");

        public ILocator FloorAndUse =>  _frameLocator.Locator("#ctl00_ContentPlaceHolder_btnFloor > span.rbPrimaryIcon.rbToggleRadio");

        public ILocator OKButton => _frameLocator.Locator(".AspPanel > #ctl00_ContentPlaceHolder_btnOK");

    }
}
