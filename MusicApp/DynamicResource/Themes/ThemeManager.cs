using MusicApp.DynamicResource.Base;
using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace MusicApp.DynamicResource.Themes
{
    public class ThemeManager: BaseManager<ThemeInfo>, IDynamicResourceManager<ThemeInfo>
    {
        private static IDynamicResourceManager<ThemeInfo> _dynamicResourceManager;

        public static IDynamicResourceManager<ThemeInfo> Instance => _dynamicResourceManager ?? (_dynamicResourceManager = new ThemeManager());
        IDynamicResourceManager<ThemeInfo> IDynamicResourceManager<ThemeInfo>.Instance => Instance;

        public static IDynamicResourceManager InstanceStock => _dynamicResourceManager ?? (_dynamicResourceManager = new ThemeManager());
        IDynamicResourceManager IDynamicResourceManager.InstanceStock => InstanceStock;

        public override object GetResource(string key)
        {
            if (string.IsNullOrEmpty(key))
                return "[NULL]";
            var localizedValue = Provider?.GetResource(key);
            return localizedValue ?? $"[{key}]";
        }
    }
}
