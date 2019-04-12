using MusicApp.DynamicResource.Base;
using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace MusicApp.DynamicResource.Themes
{
    public class ThemeManager: BaseManager<ThemeInfo>
    {
        private static BaseManager<ThemeInfo> _dynamicResourceManager;

        public override BaseManager<ThemeInfo> Instance => StaticInstance;
        public override BaseManager InstanceStock => Instance;

        public static BaseManager<ThemeInfo> StaticInstance => _dynamicResourceManager ?? (_dynamicResourceManager = new ThemeManager());

        public override object GetResource(string key)
        {
            if (string.IsNullOrEmpty(key))
                return "[NULL]";
            var localizedValue = Provider?.GetResource(key);
            return localizedValue ?? $"[{key}]";
        }
    }
}
