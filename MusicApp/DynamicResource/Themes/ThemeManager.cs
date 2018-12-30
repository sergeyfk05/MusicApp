using MusicApp.DynamicResource.Base;
using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace MusicApp.DynamicResource.Themes
{
    public class ThemeManager: IDynamicResourceManager<ThemeInfo>
    {
        private ThemeManager()
        {
        }

        private static IDynamicResourceManager<ThemeInfo> _dynamicResourceManager;

        public static IDynamicResourceManager<ThemeInfo> Instance => _dynamicResourceManager ?? (_dynamicResourceManager = new ThemeManager());
        IDynamicResourceManager<ThemeInfo> IDynamicResourceManager<ThemeInfo>.Instance => Instance;

        public static IDynamicResourceManager InstanceStock => _dynamicResourceManager ?? (_dynamicResourceManager = new ThemeManager());
        IDynamicResourceManager IDynamicResourceManager.InstanceStock => InstanceStock;


        public event EventHandler CultureChanged;

        public ThemeInfo CurrentCulture
        {
            get { return null; /*Thread.CurrentThread.CurrentUICulture;*/ }
            set
            {
                if (Equals(value, Thread.CurrentThread.CurrentUICulture))
                    return;
                //Thread.CurrentThread.CurrentUICulture = value;
                //CultureInfo.DefaultThreadCurrentUICulture = value;
                OnCultureChanged();
            }
        }

        public IEnumerable<ThemeInfo> Cultures => Provider?.Cultures ?? Enumerable.Empty<ThemeInfo>();

        public IDynamicResourceProvider<ThemeInfo> Provider { get; set; }

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
