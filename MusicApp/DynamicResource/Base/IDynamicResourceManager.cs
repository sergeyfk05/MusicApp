using System;
using System.Collections.Generic;
using System.Globalization;

namespace MusicApp.DynamicResource.Base
{
    public interface IDynamicResourceManager
    {
        IDynamicResourceManager Instance { get; }

        CultureInfo CurrentCulture { get; set; }
        event EventHandler CultureChanged;

        IEnumerable<CultureInfo> Cultures { get; }

        IDynamicResourceProvider Provider { get; set; }

        object GetResource(string key);
    }
}
