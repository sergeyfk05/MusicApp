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
        private void OnCultureChanged()
        {
            CultureChanged?.Invoke(this, EventArgs.Empty);
        }

        public CultureInfo CurrentCulture
        {
            get
            {
                if (Provider == null)
                    throw new NullReferenceException("Provider is null");

                return Provider.CurrentCulture;
            }
            set
            {
                if (Provider == null)
                    throw new NullReferenceException("Provider is null");

                if (Equals(value, Provider.CurrentCulture))
                    return;

                Provider.CurrentCulture = value;
                OnCultureChanged();
            }
        }

        public IEnumerable<CultureInfo> Cultures
        {
            get
            {
                if (Provider == null)
                    throw new NullReferenceException("Provider is null");

                return Provider.Cultures ?? Enumerable.Empty<CultureInfo>();
            }
        }

        public IDynamicResourceProvider Provider { get; set; }

        public object GetResource(string key)
        {
            if (string.IsNullOrEmpty(key))
                return "[NULL]";
            var localizedValue = Provider?.GetResource(key);
            return localizedValue ?? $"[{key}]";
        }
    }
}
