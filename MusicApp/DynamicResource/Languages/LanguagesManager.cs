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
    public class LanguagesManager : IDynamicResourceManager
    {
        private LanguagesManager()
        {
        }

        private static IDynamicResourceManager _localizationManager;

        public static IDynamicResourceManager Instance => _localizationManager ?? (_localizationManager = new LanguagesManager());
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
