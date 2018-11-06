using MusicApp.DynamicResource.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace MusicApp.DynamicResource.Themes
{
    public class ThemeManager: IDynamicResourceManager
    {
        private ThemeManager()
        {
        }

        private static IDynamicResourceManager _dynamicResourceManager;

        public static IDynamicResourceManager Instance => _dynamicResourceManager ?? (_dynamicResourceManager = new ThemeManager());
        IDynamicResourceManager IDynamicResourceManager.Instance => Instance;

        public event EventHandler CultureChanged;

        public CultureInfo CurrentCulture
        {
            get { return Thread.CurrentThread.CurrentUICulture; }
            set
            {
                if (Equals(value, Thread.CurrentThread.CurrentUICulture))
                    return;
                Thread.CurrentThread.CurrentUICulture = value;
                CultureInfo.DefaultThreadCurrentUICulture = value;
                OnCultureChanged();
            }
        }

        public IEnumerable<CultureInfo> Cultures => Provider?.Cultures ?? Enumerable.Empty<CultureInfo>();

        public IDynamicResourceProvider Provider { get; set; }

        private void OnCultureChanged()
        {
            CultureChanged?.Invoke(this, EventArgs.Empty);
        }

        public object GetResource(string key)
        {
            if (string.IsNullOrEmpty(key))
                return "[NULL]";
            var localizedValue = Provider?.GetResource(key);
            return localizedValue ?? $"[{key}]";
        }
    }
}
