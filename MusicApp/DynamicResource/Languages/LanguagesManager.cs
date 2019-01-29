using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using MusicApp.DynamicResource.Base;

namespace MusicApp.DynamicResource.Languages
{
    /// <summary>
    /// Основной класс для работы с локализацией
    /// </summary>
    public class LanguagesManager : BaseManager<CultureInfo>, IDynamicResourceManager<CultureInfo>
    {
        private static IDynamicResourceManager<CultureInfo> _localizationManager;

        public static IDynamicResourceManager<CultureInfo> Instance => _localizationManager ?? (_localizationManager = new LanguagesManager());
        IDynamicResourceManager<CultureInfo> IDynamicResourceManager<CultureInfo>.Instance => Instance;

        public static IDynamicResourceManager InstanceStock => _localizationManager ?? (_localizationManager = new LanguagesManager());
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
