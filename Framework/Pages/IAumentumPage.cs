using System;
using System.Collections.Generic;

namespace Aumentum.Framework.Pages
{
    public interface IAumentumPage
    {
        Task<T>NavigateTo<T>(string path) where T : IAumentumPage;
    }
}