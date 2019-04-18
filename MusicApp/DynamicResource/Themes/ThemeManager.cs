using MusicApp.DynamicResource;
using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace MusicApp.DynamicResource.Themes
{
    public class ThemeManager: Manager<ThemeInfo>
    {
        private static Manager<ThemeInfo> _dynamicResourceManager;

        public override Manager<ThemeInfo> Instance => StaticInstance;
        public override Manager InstanceStock => Instance;

        public static Manager<ThemeInfo> StaticInstance => _dynamicResourceManager ?? (_dynamicResourceManager = new ThemeManager());

        public override object GetResource(string key)
        {
            if (string.IsNullOrEmpty(key))
                return "[NULL]";
            var localizedValue = Provider?.GetResource(key);
            return localizedValue ?? $"[{key}]";
        }
    }
}
