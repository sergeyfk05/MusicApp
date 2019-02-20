using System;
using System.Collections.Generic;
using System.Globalization;

namespace MusicApp.DynamicResource.Base
{
    public interface IDynamicResourceManager<T> : IDynamicResourceManager
    {
        IDynamicResourceManager<T> Instance { get; }

        T CurrentCulture { get; set; }

        IEnumerable<T> Cultures { get; }

        IDynamicResourceProvider<T> Provider { set; }
    }
    public interface IDynamicResourceManager
    {
        IDynamicResourceManager InstanceStock { get; }

        event EventHandler CultureChanged;

        object GetResource(string key);
    }
}
