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
    public class LanguagesManager : BaseManager<CultureInfo>
    {
        private static BaseManager<CultureInfo> _localizationManager;

        public override BaseManager<CultureInfo> Instance => StaticInstance;
        public override BaseManager InstanceStock => Instance;

        public static BaseManager<CultureInfo> StaticInstance => _localizationManager ?? (_localizationManager = new LanguagesManager());

        public override object GetResource(string key)
        {
            if (string.IsNullOrEmpty(key))
                return "[NULL]";
            var localizedValue = Provider?.GetResource(key);
            return localizedValue ?? $"[{key}]";
        }
    }
}
