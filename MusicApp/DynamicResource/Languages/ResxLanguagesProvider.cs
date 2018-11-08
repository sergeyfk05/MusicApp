using MusicApp.DynamicResource.Base;
using MusicApp.Resources.Languages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MusicApp.DynamicResource.Languages
{
    /// <summary>
    /// Реализация поставщика локализованных строк через ресурсы приложения
    /// </summary>
    public class ResxLanguagesProvider : IDynamicResourceProvider
    {
        private IEnumerable<CultureInfo> _cultures;

        public object GetResource(string key)
        {
            return Language.ResourceManager.GetObject(key);
        }

        public IEnumerable<CultureInfo> Cultures => _cultures ?? (_cultures = new List<CultureInfo>
        {
            new CultureInfo("ru-RU"),
            new CultureInfo("en-US"),
        });

        private CultureInfo _currentCulture;
        public CultureInfo CurrentCulture
        {
            get { return _currentCulture; }
            set
            {
                if (Equals(value, _currentCulture))
                    return;

                if (!Cultures.Contains(value))
                    throw new ArgumentException("There is no such theme in the list of themes.");

                _currentCulture = value;
            }
        }
    }
}
