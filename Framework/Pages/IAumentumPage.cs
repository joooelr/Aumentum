using System;
using System.Collections.Generic;

namespace PlaywrightTests.Framework.Pages
{
    public interface IAumentumPage
    {
        Task<T>NavigateTo<T>(string path) where T : IAumentumPage;
    }
}